using Guna.UI2.WinForms;
using Hotel.Negocio_.Modelo;
using HotelZormat.Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelZormat
{
  
        public partial class FrmDashboard : Form
        {
            private HabitacionService habitacionService = new HabitacionService();

            // Timer para el refresco automático del tablero, como pide la práctica.
            private Timer timerRefresco;

            public FrmDashboard()
            {
                InitializeComponent();
            }

            private void FrmDashboard_Load(object sender, EventArgs e)
            {
                if (SesionActual.UsuarioLogueado == null)
                {
                    MessageBox.Show("Debe iniciar sesión primero.", "Sesión requerida",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                lblUsuarioActual.Text = SesionActual.UsuarioLogueado.NombreUsuario +
                    " - " + SesionActual.UsuarioLogueado.Rol;

                // El botón de Bitácora solo lo puede ver el Administrador
                btnMenuBitacora.Visible = SesionActual.EsAdministrador();

                CargarTablero();
                ConfigurarRefrescoAutomatico();
            }

            // ── Refresco automático: cada 15 segundos se vuelve a consultar ──
            // la base de datos y se redibuja el tablero, para que si otro
            // usuario cambia el estado de una habitación, se refleje solo.
            private void ConfigurarRefrescoAutomatico()
            {
                timerRefresco = new Timer();
                timerRefresco.Interval = 15000; // 15 segundos
                timerRefresco.Tick += (s, e) => CargarTablero();
                timerRefresco.Start();
            }

            // ── Consulta las habitaciones y dibuja una tarjeta por cada una ──
            private void CargarTablero()
            {
                try
                {
                    List<Habitacion> habitaciones = habitacionService.ObtenerTodas();

                    flpHabitaciones.Controls.Clear();

                    foreach (Habitacion habitacion in habitaciones)
                    {
                        Guna2Panel tarjeta = CrearTarjetaHabitacion(habitacion);
                        flpHabitaciones.Controls.Add(tarjeta);
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

            // ── Crea visualmente una tarjeta (Guna2Panel) para una habitación ──
            // El color se decide con un switch sobre el estado, tal como pide
            // la práctica ("Implementado con switch sobre el estado").
            private Guna2Panel CrearTarjetaHabitacion(Habitacion habitacion)
            {
                Guna2Panel tarjeta = new Guna2Panel();
                tarjeta.Size = new Size(110, 80);
                tarjeta.Margin = new Padding(6);
                tarjeta.BorderRadius = 10;
                tarjeta.FillColor = ObtenerColorPorEstado(habitacion.Estado);
                tarjeta.Cursor = Cursors.Hand;

                Label lblNumero = new Label();
                lblNumero.Text = habitacion.Numero.ToString();
                lblNumero.ForeColor = Color.White;
                lblNumero.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                lblNumero.AutoSize = false;
                lblNumero.TextAlign = ContentAlignment.MiddleCenter;
                lblNumero.Dock = DockStyle.Top;
                lblNumero.Height = 45;
                lblNumero.BackColor = Color.Transparent;

                Label lblTipo = new Label();
                lblTipo.Text = habitacion.Tipo;
                lblTipo.ForeColor = Color.White;
                lblTipo.Font = new Font("Segoe UI", 8);
                lblTipo.AutoSize = false;
                lblTipo.TextAlign = ContentAlignment.MiddleCenter;
                lblTipo.Dock = DockStyle.Fill;
                lblTipo.BackColor = Color.Transparent;

                tarjeta.Controls.Add(lblTipo);
                tarjeta.Controls.Add(lblNumero);

                // Al hacer clic en la tarjeta, se abre la gestión de esa habitación
                tarjeta.Click += (s, e) => AbrirGestionHabitacion(habitacion.Numero);
                lblNumero.Click += (s, e) => AbrirGestionHabitacion(habitacion.Numero);
                lblTipo.Click += (s, e) => AbrirGestionHabitacion(habitacion.Numero);

                return tarjeta;
            }

            // ── Switch que decide el color según el estado ────────────────
            private Color ObtenerColorPorEstado(string estado)
            {
                Color color;

                switch (estado)
                {
                    case EstadosHabitacion.Disponible:
                        color = Color.FromArgb(99, 153, 34);   // verde
                        break;
                    case EstadosHabitacion.Ocupada:
                        color = Color.FromArgb(226, 75, 74);   // rojo
                        break;
                    case EstadosHabitacion.Reservada:
                        color = Color.FromArgb(239, 159, 39);  // naranja
                        break;
                    case EstadosHabitacion.Limpieza:
                        color = Color.FromArgb(55, 138, 221);  // azul
                        break;
                    default:
                        color = Color.Gray;
                        break;
                }

                return color;
            }

            private void AbrirGestionHabitacion(int numeroHabitacion)
            {
                FrmHabitacionGestiion frm = new FrmHabitacionGestiion();
                frm.ShowDialog();
                CargarTablero(); // al cerrar esa ventana, refrescamos el tablero
            }

            private void btnMenuHabitaciones_Click(object sender, EventArgs e)
            {
                AbrirGestionHabitacion(0);
            }

            private void btnCerrarSesion_Click(object sender, EventArgs e)
            {
                DialogResult respuesta = MessageBox.Show("¿Desea cerrar sesión?", "Confirmación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    timerRefresco.Stop();
                    SesionActual.UsuarioLogueado = null;
                    this.Close();

                    FrmPRINCIPAL login = new FrmPRINCIPAL();
                    login.Show();
                }
            }

        private void flpHabitaciones_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMenuHuesped_Click(object sender, EventArgs e)
        {
            FrmHuesped frm = new FrmHuesped();
            frm.Show();
        }
    }
    
}

