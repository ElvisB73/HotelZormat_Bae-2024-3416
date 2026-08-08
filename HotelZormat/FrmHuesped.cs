// Cedula: 402444623662
using Hotel.Negocio_.Modelo;
using HotelZormat.Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace HotelZormat
{
    public partial class FrmHuesped : Form
    {
        private HuespedService huespedService = new HuespedService();

        private int? idSeleccionado = null;

        public FrmHuesped()
        {
            InitializeComponent();
        }

        private void FrmHuesped_Load(object sender, EventArgs e)
        {
           
            lstHuespedes.View = View.Details;
            lstHuespedes.Columns.Clear();
            lstHuespedes.Columns.Add("Documento", 130);
            lstHuespedes.Columns.Add("Nombre", 100);
            lstHuespedes.Columns.Add("Apellido", 100);
            lstHuespedes.Columns.Add("Teléfono", 110);

            cboTipoDocumento.Items.Clear();
            cboTipoDocumento.Items.Add(TiposDocumento.Cedula);
            cboTipoDocumento.Items.Add(TiposDocumento.Pasaporte);

            CargarLista(null);
            LimpiarFormulario();
        }

        private void cboTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si es Cédula, no deja escribir más de 11 caracteres.
            // Si es Pasaporte (o no ha seleccionado nada todavía), lo deja más libre,
            // porque el formato de pasaporte varía según el país.
            if (cboTipoDocumento.SelectedItem != null
                && cboTipoDocumento.SelectedItem.ToString() == TiposDocumento.Cedula)
            {
                txtNumeroDocumento.MaxLength = 11;
            }
            else
            {
                txtNumeroDocumento.MaxLength = 20;
            }
        }

        private void CargarLista(string textoBusqueda)
        {
            try
            {
                lstHuespedes.Items.Clear();

                List<Huesped> huespedes = string.IsNullOrWhiteSpace(textoBusqueda)
                    ? huespedService.ObtenerTodos()
                    : huespedService.Buscar(textoBusqueda);

                foreach (Huesped huesped in huespedes)
                {
                    ListViewItem fila = new ListViewItem(huesped.NumeroDocumento);
                    fila.SubItems.Add(huesped.Nombre);
                    fila.SubItems.Add(huesped.Apellido);
                    fila.SubItems.Add(huesped.Telefono);
                    fila.Tag = huesped.Id;
                    lstHuespedes.Items.Add(fila);
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarLista(txtBuscar.Text.Trim());
        }

        private void lstHuespedes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstHuespedes.SelectedItems.Count == 0)
            {
                return;
            }

            try
            {
                int id = (int)lstHuespedes.SelectedItems[0].Tag;
                Huesped huesped = huespedService.ObtenerPorId(id);

                if (huesped == null)
                {
                    return;
                }

                idSeleccionado = huesped.Id;
                cboTipoDocumento.SelectedItem = huesped.TipoDocumento;
                txtNumeroDocumento.Text = huesped.NumeroDocumento;
                txtNombre.Text = huesped.Nombre;
                txtApellido.Text = huesped.Apellido;
                txtNacionalidad.Text = huesped.Nacionalidad;
                txtTelefono.Text = huesped.Telefono;
                txtEmail.Text = huesped.Email;
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            idSeleccionado = null;
            cboTipoDocumento.SelectedIndex = -1;
            txtNumeroDocumento.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtNacionalidad.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Huesped huesped = new Huesped
                {
                    Id = idSeleccionado ?? 0,
                    TipoDocumento = cboTipoDocumento.SelectedItem?.ToString(),
                    NumeroDocumento = txtNumeroDocumento.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Nacionalidad = txtNacionalidad.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };

                if (idSeleccionado.HasValue)
                {
                    huespedService.Actualizar(huesped);
                    MessageBox.Show("Huésped actualizado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    huespedService.Crear(huesped);
                    MessageBox.Show("Huésped creado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimpiarFormulario();
                CargarLista(null);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!idSeleccionado.HasValue)
            {
                MessageBox.Show("Seleccione un huésped de la lista primero.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro que desea eliminar este huésped?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            try
            {
                huespedService.Eliminar(idSeleccionado.Value);
                MessageBox.Show("Huésped eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarLista(null);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                // Error 547 de SQL Server = violación de llave foránea.
                // Significa que este huésped tiene reservas o estadías asociadas.
                MessageBox.Show(
                    "No se puede eliminar este huésped porque tiene reservas o estadías registradas a su nombre.",
                    "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnVerHistorial_Click(object sender, EventArgs e)
        {
            if (!idSeleccionado.HasValue)
            {
                MessageBox.Show("Seleccione un huésped de la lista primero.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                List<Dictionary<string, object>> historial = huespedService.ObtenerHistorial(idSeleccionado.Value);

                if (historial.Count == 0)
                {
                    MessageBox.Show("Este huésped no tiene estadías registradas.", "Historial",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                StringBuilder texto = new StringBuilder();
                foreach (Dictionary<string, object> fila in historial)
                {
                    texto.Append("Habitación " + fila["Numero"] + " - Check-in: " + fila["CheckIn"]);
                    texto.Append(fila["CheckOut"] != null ? " - Check-out: " + fila["CheckOut"] : " (en curso)");
                    texto.Append("\n");
                }

                MessageBox.Show(texto.ToString(), "Historial de estadías",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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