// Cedula: 402444623662
using Hotel.Negocio_.DaL;
using Hotel.Negocio_.Modelo;
using HotelZormat.Negocio.Servicios;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelZormat
{
    public partial class FrmPRINCIPAL : Form
    {
        private UsuarioService usuarioService = new UsuarioService();
        private BitacoraDAL bitacoraDal = new BitacoraDAL();

        public FrmPRINCIPAL()
        {
            InitializeComponent();
        }

        // Nombre exacto que usa el Designer: "FrmPRINCIPAL_Load"
        private void FrmPRINCIPAL_Load(object sender, EventArgs e)
        {
            lblmensaje.Text = "";
            txtContrasena.PasswordChar = '*';
        }

        // El Designer conecta el evento Paint del panel a este método.
        // Lo dejamos vacío, no necesitamos dibujar nada especial ahí.
        //private void PnlLateral_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        //{
        // }

        // El Designer conecta el Click de este label a este método.
        // Lo dejamos vacío, no hace falta que haga nada.
        private void lblNombre_Click(object sender, EventArgs e)
        {
        }

        private void btnIniciarsesion_Click_1(object sender, EventArgs e)
        {
            lblmensaje.Text = "";
            btnIniciarsesion.Enabled = false;

            try
            {
                string usuarioIngresado = txtUsuario.Text.Trim();
                string contrasenaIngresada = txtContrasena.Text;

                if (string.IsNullOrWhiteSpace(usuarioIngresado) || string.IsNullOrWhiteSpace(contrasenaIngresada))
                {
                    throw new FormatException("Debe escribir el usuario y la contraseña.");
                }

                Usuario usuario = usuarioService.ValidarLogin(usuarioIngresado, contrasenaIngresada);

                if (usuario == null)
                {
                    lblmensaje.Text = "Usuario o contraseña incorrectos.";
                    return;
                }

                // Guardamos el usuario logueado para el resto de la aplicación
                SesionActual.UsuarioLogueado = usuario;

                // Dejamos constancia del login en la bitácora
                bitacoraDal.Registrar(usuario.Id, "Login", "Inicio de sesión de " + usuario.NombreUsuario);

                MessageBox.Show(
                    "Bienvenido, " + usuario.NombreCompleto + " (" + usuario.Rol + ")",
                    "Acceso concedido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

               //  aquí se abrirá el Dashboard cuando lo construyamos.
                 this.Hide();
                FrmDashboard dashboard = new FrmDashboard();
                dashboard.ShowDialog();
                this.Close();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException)
            {
                MessageBox.Show(
                    "No se pudo conectar con la base de datos. Verifique su conexión.",
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnIniciarsesion.Enabled = true;
            }

        }
    }
}