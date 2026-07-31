using Hotel.Negocio_;
using Hotel.Negocio_.DaL;
using Hotel.Negocio_.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelZormat
{
    public partial class FrmHabitacionGestiion : Form
    {
        private HabitacionDAL dal = new HabitacionDAL();
        private Habitacion habitacionActual = null;

        public FrmHabitacionGestiion()
        {
            InitializeComponent();
        }

        private void FrmHabitacionGestiion_Load(object sender, EventArgs e)
        {
            cboTipo.Items.Clear();
            cboTipo.Items.Add("SENCILLA");
            cboTipo.Items.Add("DOBLE");
            cboTipo.Items.Add("SUITE");
            cboTipo.SelectedIndex = 0;

            CargarHabitacionesPiso3();
        }

        private void CargarHabitacionesPiso3()
        {
            lstHabitaciones.Items.Clear();

            List<Habitacion> habitacionesPiso3 = dal.ObtenerPorPiso(3);

            foreach (Habitacion h in habitacionesPiso3)
            {
                lstHabitaciones.Items.Add(h.Numero + " - " + h.Tipo);
            }
        }

        private decimal ObtenerTarifa(string tipo)
        {
            decimal tarifa;

            switch (tipo)
            {
                case "SENCILLA":
                    tarifa = 2500m;
                    break;
                case "DOBLE":
                    tarifa = 4000m;
                    break;
                case "SUITE":
                    tarifa = 7000m;
                    break;
                default:
                    throw new ArgumentException("Tipo desconocido: " + tipo);
            }

            return tarifa;
        }

        private Color ObtenerColorEstado(string estado)
        {
            Color color;

            switch (estado)
            {
                case "DISPONIBLE":
                    color = Color.Green;
                    break;
                case "OCUPADA":
                    color = Color.Red;
                    break;
                case "RESERVADA":
                    color = Color.Blue;
                    break;
                case "LIMPIEZA":
                    color = Color.Orange;
                    break;
                default:
                    color = Color.Black;
                    break;
            }

            return color;
        }

        private void ConfigurarBotones(string estado)
        {
            btnCheckIn.Enabled = false;
            btnCheckOut.Enabled = false;
            btnReservar.Enabled = false;
            btnLimpiar.Enabled = false;

            switch (estado)
            {
                case "DISPONIBLE":
                    btnCheckIn.Enabled = true;
                    break;
                case "OCUPADA":
                    btnCheckOut.Enabled = true;
                    break;
                case "RESERVADA":
                    btnReservar.Enabled = true;
                    break;
                case "LIMPIEZA":
                    btnLimpiar.Enabled = true;
                    break;
            }
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboTipo.Text)
            {
                case "SENCILLA":
                    lblIcono.Text = "Individual";
                    break;
                case "DOBLE":
                    lblIcono.Text = "Doble";
                    break;
                case "SUITE":
                    lblIcono.Text = "Suite";
                    break;
                default:
                    lblIcono.Text = "Desconocido";
                    break;
            }

            try
            {
                decimal tarifa = ObtenerTarifa(cboTipo.Text);
                lblTarifa.Text = "Tarifa: RD$ " + tarifa.ToString("N2");
            }
            catch (ArgumentException ex)
            {
                lblTarifa.Text = ex.Message;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int numero = int.Parse(txtBuscar.Text.Trim());

                habitacionActual = dal.BuscarPorNumero(numero);

                if (habitacionActual == null)
                {
                    throw new Exception("No se encontró la habitación " + numero + ".");
                }

                habitacionActual.Estado = habitacionActual.Estado.ToUpper();

                lblEstado.Text = "Estado: " + habitacionActual.Estado;
                lblEstado.ForeColor = ObtenerColorEstado(habitacionActual.Estado);
                cboTipo.Text = habitacionActual.Tipo;
                ConfigurarBotones(habitacionActual.Estado);
            }
            catch (FormatException)
            {
                MessageBox.Show("Debe escribir un número válido.", "Advertencia", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string ObtenerMensajeConfirmacion(string accion)
        {
            string mensaje;

            switch (accion)
            {
                case "CheckIn":
                    mensaje = "¿Desea realizar el Check In?";
                    break;
                case "CheckOut":
                    mensaje = "¿Desea realizar el Check Out?";
                    break;
                case "Reservar":
                    mensaje = "¿Desea realizar la Reserva?";
                    break;
                case "Limpiar":
                    mensaje = "¿Desea marcar la habitación para Limpieza?";
                    break;
                default:
                    mensaje = "¿Confirmar acción?";
                    break;
            }

            return mensaje;
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(ObtenerMensajeConfirmacion("CheckIn"), "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                GuardarCambio("OCUPADA");
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(ObtenerMensajeConfirmacion("CheckOut"), "Confirmación", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                GuardarCambio("DISPONIBLE");
            }
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(ObtenerMensajeConfirmacion("Reservar"), "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                GuardarCambio("RESERVADA");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(ObtenerMensajeConfirmacion("Limpiar"), "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                GuardarCambio("LIMPIEZA");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (habitacionActual == null)
            {
                MessageBox.Show("Primero busque una habitación.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GuardarCambio(habitacionActual.Estado);
        }

        private void GuardarCambio(string nuevoEstado)
        {
            btnGuardar.Enabled = false;

            try
            {
                if (habitacionActual == null)
                {
                    throw new Exception("Primero busque una habitación.");
                }

                if (nuevoEstado == "OCUPADA" && habitacionActual.Estado == "OCUPADA")
                {
                    throw new HabitacionException(habitacionActual.Numero);
                }

                dal.ActualizarEstado(habitacionActual.Numero, nuevoEstado);

                habitacionActual.Estado = nuevoEstado;

                lblEstado.Text = "Estado: " + nuevoEstado;
                lblEstado.ForeColor = ObtenerColorEstado(nuevoEstado);
                ConfigurarBotones(nuevoEstado);

                CargarHabitacionesPiso3();

                MessageBox.Show("Cambio guardado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (HabitacionException ex)
            {
                MessageBox.Show(ex.Message, "Habitación Ocupada",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardar.Enabled = true;
            }
        }
    }
}