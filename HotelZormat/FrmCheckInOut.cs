// Cedula: 402444623662
using Hotel.Negocio_.Modelo;
using HotelZormat.Negocio.Servicios;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelZormat
{
    public partial class FrmCheckInOut : Form
    {
        private EstadiaService estadiaService = new EstadiaService();

        public FrmCheckInOut()
        {
            InitializeComponent();
        }

        private void FrmCheckInOut_Load(object sender, EventArgs e)
        {
            lstReservasConfirmadas.View = View.Details;
            lstReservasConfirmadas.Columns.Clear();
            lstReservasConfirmadas.Columns.Add("Hab.", 60);
            lstReservasConfirmadas.Columns.Add("Huésped", 140);
            lstReservasConfirmadas.Columns.Add("Check-in", 90);

            lstHabitacionesOcupadas.View = View.Details;
            lstHabitacionesOcupadas.Columns.Clear();
            lstHabitacionesOcupadas.Columns.Add("Hab.", 60);
            lstHabitacionesOcupadas.Columns.Add("Huésped", 140);
            lstHabitacionesOcupadas.Columns.Add("Desde", 90);

            lblFactura.Text = "";

            CargarListas();
        }

        private void CargarListas()
        {
            try
            {
                lstReservasConfirmadas.Items.Clear();
                foreach (Reserva reserva in estadiaService.ObtenerReservasConfirmadas())
                {
                    ListViewItem fila = new ListViewItem(reserva.NumeroHabitacion.ToString());
                    fila.SubItems.Add(reserva.NombreHuesped);
                    fila.SubItems.Add(reserva.FechaCheckIn.ToShortDateString());
                    fila.Tag = reserva.Id;
                    lstReservasConfirmadas.Items.Add(fila);
                }

                lstHabitacionesOcupadas.Items.Clear();
                foreach (Estadia estadia in estadiaService.ObtenerEstadiasActivas())
                {
                    ListViewItem fila = new ListViewItem(estadia.NumeroHabitacion.ToString());
                    fila.SubItems.Add(estadia.NombreHuesped);
                    fila.SubItems.Add(estadia.FechaCheckInReal.ToShortDateString());
                    fila.Tag = estadia.NumeroHabitacion;
                    lstHabitacionesOcupadas.Items.Add(fila);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("No se pudo conectar con la base de datos.", "Error de conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Check-in: convierte la reserva seleccionada en estadía ────
        private void btnHacerCheckIn_Click(object sender, EventArgs e)
        {
            if (lstReservasConfirmadas.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione una reserva confirmada primero.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int reservaId = (int)lstReservasConfirmadas.SelectedItems[0].Tag;

            try
            {
                estadiaService.HacerCheckIn(reservaId, SesionActual.UsuarioLogueado.Id);

                MessageBox.Show("Check-in realizado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarListas();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "No se pudo completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException)
            {
                MessageBox.Show("No se pudo conectar con la base de datos.", "Error de conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Check-out: cierra la estadía, genera la factura con NCF ───
        private void btnHacerCheckOut_Click(object sender, EventArgs e)
        {
            if (lstHabitacionesOcupadas.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione una habitación ocupada primero.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int numeroHabitacion = (int)lstHabitacionesOcupadas.SelectedItems[0].Tag;

            try
            {
                Factura factura = estadiaService.HacerCheckOut(numeroHabitacion, SesionActual.UsuarioLogueado.Id);

                lblFactura.Text =
                    "NCF: " + factura.NCF +
                    "\nSubtotal: RD$ " + factura.Subtotal.ToString("N2") +
                    "\nITBIS (18%): RD$ " + factura.ITBIS.ToString("N2") +
                    "\nPropina (10%): RD$ " + factura.Propina.ToString("N2") +
                    "\nTotal: RD$ " + factura.Total.ToString("N2");

                MessageBox.Show("Check-out realizado. Factura " + factura.NCF + " generada.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarListas();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "No se pudo completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException)
            {
                MessageBox.Show("No se pudo conectar con la base de datos.", "Error de conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}