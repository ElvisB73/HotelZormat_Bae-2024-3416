// Cedula: 402444623662
using Hotel.Negocio_.Modelo;
using HotelZormat.Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelZormat
{
    public partial class Frmreserva : Form
    {
        private ReservaService reservaService = new ReservaService();
        private HabitacionService habitacionService = new HabitacionService();
        private HuespedService huespedService = new HuespedService();

        // Se guarda el huésped encontrado con el buscador, para usar su
        // Id al crear la reserva.
        private Huesped huespedSeleccionado = null;

        public Frmreserva()
        {
            InitializeComponent();
        }

        private void Frmreserva_Load(object sender, EventArgs e)
        {
          

            lstReservasProximas.View = View.Details;
            lstReservasProximas.Columns.Clear();
            lstReservasProximas.Columns.Add("Hab.", 60);
            lstReservasProximas.Columns.Add("Huésped", 140);
            lstReservasProximas.Columns.Add("Check-in", 90);
            lstReservasProximas.Columns.Add("Estado", 90);

            cboTemporada.Items.Clear();
            cboTemporada.Items.Add(Temporadas.Alta);
            cboTemporada.Items.Add(Temporadas.Media);
            cboTemporada.Items.Add(Temporadas.Baja);
            cboTemporada.SelectedIndex = 0;

            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today.AddDays(1);

            CargarHabitacionesDisponibles();
            CargarProximasReservas();
            ActualizarCalculo();
        }

        // ── Solo muestra habitaciones que estén Disponibles para reservar ──
        private void CargarHabitacionesDisponibles()
        {
            cbohabitacion.Items.Clear();

            foreach (Habitacion habitacion in habitacionService.ObtenerConFiltros(null, EstadosHabitacion.Disponible))
            {
                cbohabitacion.Items.Add(habitacion.Numero);
            }
        }

        private void CargarProximasReservas()
        {
            try
            {
                lstReservasProximas.Items.Clear();

                foreach (Reserva reserva in reservaService.ObtenerProximas7Dias())
                {
                    ListViewItem fila = new ListViewItem(reserva.NumeroHabitacion.ToString());
                    fila.SubItems.Add(reserva.NombreHuesped);
                    fila.SubItems.Add(reserva.FechaCheckIn.ToShortDateString());
                    fila.SubItems.Add(reserva.Estado);
                    fila.Tag = reserva.Id;
                    lstReservasProximas.Items.Add(fila);
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

        // ── Busca el huésped por cédula o pasaporte ───────────────────
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Huesped> encontrados = huespedService.Buscar(txtBuscarHuesped.Text.Trim());

                if (encontrados.Count == 0)
                {
                    huespedSeleccionado = null;
                    lblHuespedEncontrado.Text = "No se encontró ningún huésped con ese documento.";
                    return;
                }

                huespedSeleccionado = encontrados[0];
                lblHuespedEncontrado.Text = huespedSeleccionado.Nombre + " " + huespedSeleccionado.Apellido;
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

        // ── Recalcula noches y monto cada vez que cambian las fechas,
        // la temporada, o la habitación seleccionada ──────────────────
        private void ActualizarCalculo()
        {
            try
            {
                if (cbohabitacion.SelectedItem == null || cboTemporada.SelectedItem == null)
                {
                    lblNoches.Text = "Noches: --";
                    lblMonto.Text = "Monto: RD$ 0.00";
                    return;
                }

                int noches = (dtpCheckOut.Value.Date - dtpCheckIn.Value.Date).Days;

                if (noches <= 0)
                {
                    lblNoches.Text = "Noches: --";
                    lblMonto.Text = "Monto: RD$ 0.00";
                    return;
                }

                int numeroHabitacion = (int)cbohabitacion.SelectedItem;
                Habitacion habitacion = habitacionService.BuscarPorNumero(numeroHabitacion);

                if (habitacion == null)
                {
                    return;
                }

                decimal monto = reservaService.CalcularMontoTotal(
                    habitacion.Tarifa, noches, cboTemporada.SelectedItem.ToString());

                lblNoches.Text = "Noches: " + noches;
                lblMonto.Text = "Monto: RD$ " + monto.ToString("N2");
            }
            catch (Exception)
            {
                // Si algo falla en el cálculo en vivo, simplemente no se
                // actualiza la etiqueta; el error real se atrapa al
                // intentar crear la reserva.
            }
        }

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
            ActualizarCalculo();
        }

        private void dtpCheckOut_ValueChanged(object sender, EventArgs e)
        {
            ActualizarCalculo();
        }

        private void cboTemporada_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarCalculo();
        }

        private void cbohabitacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarCalculo();
        }

        // ── Crea la reserva ────────────────────────────────────────────
        private void btnCrearReserva_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbohabitacion.SelectedItem == null)
                {
                    throw new FormatException("Seleccione una habitación.");
                }

                if (huespedSeleccionado == null)
                {
                    throw new FormatException("Busque y seleccione un huésped primero.");
                }

                int numeroHabitacion = (int)cbohabitacion.SelectedItem;
                string temporada = cboTemporada.SelectedItem.ToString();

                reservaService.CrearReserva(numeroHabitacion, huespedSeleccionado.Id,
                    dtpCheckIn.Value.Date, dtpCheckOut.Value.Date, temporada);

                MessageBox.Show("Reserva creada correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                huespedSeleccionado = null;
                lblHuespedEncontrado.Text = "";
                txtBuscarHuesped.Text = "";

                CargarHabitacionesDisponibles();
                CargarProximasReservas();
                ActualizarCalculo();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Hotel.Negocio_.HabitacionException ex)
            {
                MessageBox.Show("La habitación " + ex.NumeroHabitacion + " ya no está disponible.",
                    "No se puede reservar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            CambiarEstadoSeleccionada(confirmar: true);
        }

        private void lblCancelar_Click(object sender, EventArgs e)
        {
            CambiarEstadoSeleccionada(confirmar: false);
        }

        private void CambiarEstadoSeleccionada(bool confirmar)
        {
            if (lstReservasProximas.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione una reserva de la lista primero.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int reservaId = (int)lstReservasProximas.SelectedItems[0].Tag;

            try
            {
                if (confirmar)
                {
                    reservaService.ConfirmarReserva(reservaId);
                    MessageBox.Show("Reserva confirmada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    reservaService.CancelarReserva(reservaId);
                    MessageBox.Show("Reserva cancelada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CargarProximasReservas();
                CargarHabitacionesDisponibles();
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

        // Generados sin querer por el diseñador al hacer clic en estos
        // labels. Se dejan vacíos, no hacen nada.
        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}