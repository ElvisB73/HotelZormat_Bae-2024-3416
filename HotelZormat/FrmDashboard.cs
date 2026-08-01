// Cedula: 402444623662
using Guna.UI2.WinForms;
using Hotel.Negocio_.Modelo;
using HotelZormat.Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HotelZormat
{
    public partial class FrmDashboard : Form
    {
        // TODO: confirma que los nombres de los controles del Designer coincidan
        // exacto con los usados aquí: flpHabitaciones, flpLeyenda, lblUsuarioActual,
        // btnMenuHabitaciones, btnMenuHuespedes, btnMenuReservas, btnMenuCheckInOut,
        // btnMenuReportes, btnMenuBitacora, btnCerrarSesion.
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
            CargarLeyenda();
        }

        // ── Arma la leyenda de colores (un cuadrito + su significado) ──
        private void CargarLeyenda()
        {
            //flpLeyenda.Controls.Clear();

            AgregarItemLeyenda("Disponible", ObtenerColorPorEstado(EstadosHabitacion.Disponible));
            AgregarItemLeyenda("Ocupada", ObtenerColorPorEstado(EstadosHabitacion.Ocupada));
            AgregarItemLeyenda("Reservada", ObtenerColorPorEstado(EstadosHabitacion.Reservada));
            AgregarItemLeyenda("Limpieza", ObtenerColorPorEstado(EstadosHabitacion.Limpieza));
        }

        // ── Crea un cuadrito de color + su etiqueta de texto ──────────
        private void AgregarItemLeyenda(string texto, Color color)
        {
            Panel contenedor = new Panel();
            contenedor.Size = new Size(110, 24);
            contenedor.Margin = new Padding(4, 6, 12, 6);

            Panel cuadrito = new Panel();
            cuadrito.Size = new Size(16, 16);
            cuadrito.Location = new Point(0, 4);
            cuadrito.BackColor = color;

            Label etiqueta = new Label();
            etiqueta.Text = texto;
            etiqueta.AutoSize = true;
            etiqueta.Location = new Point(22, 3);
            etiqueta.Font = new Font("Segoe UI", 8.5f);

            contenedor.Controls.Add(cuadrito);
            contenedor.Controls.Add(etiqueta);

           // flpLeyenda.Controls.Add(contenedor);
        }

        // ── Refresco automático: cada 15 segundos se vuelve a consultar ──
        // la base de datos y se redibuja el tablero, para que si otro
        // usuario cambia el estado de una habitación, se refleje solo.
        private void ConfigurarRefrescoAutomatico()
        {
            // TODO: el Timer se detiene explícitamente en btnCerrarSesion_Click,
            // pero si el usuario cierra este formulario con la X de la ventana
            // (en vez de usar el botón), el Timer sigue corriendo hasta que se
            // cierra toda la aplicación. No debería causar un error visible,
            // pero sería más prolijo también detenerlo en el evento FormClosing.
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
            // TODO: numeroHabitacion no se está usando todavía. La idea original
            // era que al hacer clic en una tarjeta, FrmHabitacionGestiion abriera
            // ya con esa habitación cargada en el formulario, en vez de abrir en
            // blanco. Habría que agregarle a FrmHabitacionGestiion un constructor
            // que reciba el número y llame a lstHabitaciones_SelectedIndexChanged
            // (o algo equivalente) para precargar los datos.
            FrmHabitacionGestiion frm = new FrmHabitacionGestiion();
            frm.ShowDialog();
            CargarTablero(); // al cerrar esa ventana, refrescamos el tablero
        }

        private void btnMenuHabitaciones_Click(object sender, EventArgs e)
        {
            AbrirGestionHabitacion(0);
        }

        private void btnMenuHuespedes_Click(object sender, EventArgs e)
        {
            FrmHuesped frm = new FrmHuesped();
            frm.ShowDialog();
        }

        private void btnMenuReservas_Click(object sender, EventArgs e)
        {
            Frmreserva frm = new Frmreserva();
            frm.ShowDialog();
            CargarTablero();
        }

        private void btnMenuCheckInOut_Click(object sender, EventArgs e)
        {
            FrmCheckInOut frm = new FrmCheckInOut();
            frm.ShowDialog();
            CargarTablero();
        }

        private void btnMenuReportes_Click(object sender, EventArgs e)
        {
            FrmReporte frm = new FrmReporte();
            frm.ShowDialog();
        }

        private void btnMenuBitacora_Click(object sender, EventArgs e)
        {
            FrmBitacora frm = new FrmBitacora();
            frm.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // TODO IMPORTANTE: Program.cs arranca la aplicación con
            // Application.Run(new FrmPRINCIPAL()) — eso significa que la app
            // completa se cierra quando esa PRIMERA instancia de FrmPRINCIPAL
            // se cierra, sin importar que aquí abramos una instancia NUEVA del
            // login con "login.Show()". Hay que probar esto con cuidado: es
            // posible que al cerrar sesión, la ventana de login nueva aparezca
            // y se cierre casi de inmediato, o que la aplicación se cierre
            // completa en vez de regresar al login. Si pasa eso, la solución
            // más simple es no cerrar FrmPRINCIPAL desde adentro del login,
            // sino que Program.cs controle el ciclo completo (mostrar login,
            // si el login es exitoso mostrar dashboard, al cerrar dashboard
            // volver a mostrar el MISMO login en vez de crear uno nuevo).
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
    }
}