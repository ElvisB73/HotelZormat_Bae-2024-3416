// Cedula: 402444623662
using Hotel.Negocio_.Modelo;
using HotelZormat.Negocio.Servicios;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelZormat
{
    public partial class FrmHabitacionGestiion : Form
    {
        private HabitacionService habitacionService = new HabitacionService();

        // Guarda el número de la habitación que está seleccionada en la
        // lista para saber si btnGuardar debe Crear o Actualizar.
        private int? numeroSeleccionado = null;

        public FrmHabitacionGestiion()
        {
            InitializeComponent();
        }

        private void FrmHabitacionGestiion_Load(object sender, EventArgs e)
        {

            cboTipo.Items.Clear();
            cboTipo.Items.Add(TiposHabitacion.Sencilla);
            cboTipo.Items.Add(TiposHabitacion.Doble);
            cboTipo.Items.Add(TiposHabitacion.Suite);

            cboEstado.Items.Clear();
            cboEstado.Items.Add(EstadosHabitacion.Disponible);
            cboEstado.Items.Add(EstadosHabitacion.Ocupada);
            cboEstado.Items.Add(EstadosHabitacion.Reservada);
            cboEstado.Items.Add(EstadosHabitacion.Limpieza);

            cboFiltroPiso.Items.Clear();
            cboFiltroPiso.Items.Add("Todos");
            for (int piso = 1; piso <= 5; piso++)
            {
                cboFiltroPiso.Items.Add(piso.ToString());
            }
            cboFiltroPiso.SelectedIndex = 0;

            cboFiltroEstado.Items.Clear();
            cboFiltroEstado.Items.Add("Todos");
            cboFiltroEstado.Items.Add(EstadosHabitacion.Disponible);
            cboFiltroEstado.Items.Add(EstadosHabitacion.Ocupada);
            cboFiltroEstado.Items.Add(EstadosHabitacion.Reservada);
            cboFiltroEstado.Items.Add(EstadosHabitacion.Limpieza);
            cboFiltroEstado.SelectedIndex = 0;

            CargarLista(null, null);
            LimpiarFormulario();
        }

        // ── Carga la lista aplicando filtros de piso y estado ────────
        private void CargarLista(int? piso, string estado)
        {
            try
            {
                lstHabitaciones.Items.Clear();

                foreach (Habitacion habitacion in habitacionService.ObtenerConFiltros(piso, estado))
                {
                    ListViewItem fila = new ListViewItem(habitacion.Numero.ToString());
                    fila.SubItems.Add(habitacion.Tipo);
                    fila.SubItems.Add(habitacion.Piso.ToString());
                    fila.SubItems.Add(habitacion.Estado);
                    lstHabitaciones.Items.Add(fila);
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

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            int? piso = null;
            if (cboFiltroPiso.SelectedItem != null && cboFiltroPiso.SelectedItem.ToString() != "Todos")
            {
                piso = int.Parse(cboFiltroPiso.SelectedItem.ToString());
            }

            string estado = null;
            if (cboFiltroEstado.SelectedItem != null && cboFiltroEstado.SelectedItem.ToString() != "Todos")
            {
                estado = cboFiltroEstado.SelectedItem.ToString();
            }

            CargarLista(piso, estado);
        }

        // ── Al hacer clic en una fila, se cargan sus datos en el formulario ──
        private void lstHabitaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstHabitaciones.SelectedItems.Count == 0)
            {
                return;
            }

            ListViewItem fila = lstHabitaciones.SelectedItems[0];

            int numero = int.Parse(fila.SubItems[0].Text);
            Habitacion habitacion = habitacionService.BuscarPorNumero(numero);

            if (habitacion == null)
            {
                return;
            }

            numeroSeleccionado = habitacion.Numero;
            txtNumero.Text = habitacion.Numero.ToString();
            txtNumero.Enabled = false; // no se permite cambiar el número de una habitación existente
            cboTipo.SelectedItem = habitacion.Tipo;
            txtPiso.Text = habitacion.Piso.ToString();
            txtCapacidad.Text = habitacion.Capacidad.ToString();
            txtTarifa.Text = habitacion.Tarifa.ToString();
            cboEstado.SelectedItem = habitacion.Estado;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            numeroSeleccionado = null;
            txtNumero.Text = "";
            txtNumero.Enabled = true;
            cboTipo.SelectedIndex = -1;
            txtPiso.Text = "";
            txtCapacidad.Text = "";
            txtTarifa.Text = "";
            cboEstado.SelectedIndex = -1;
        }

        // ── Crea o actualiza, según si hay una habitación seleccionada ──
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Habitacion habitacion = new Habitacion
                {
                    Numero = int.Parse(txtNumero.Text),
                    Tipo = cboTipo.SelectedItem?.ToString(),
                    Piso = int.Parse(txtPiso.Text),
                    Capacidad = int.Parse(txtCapacidad.Text),
                    Tarifa = decimal.Parse(txtTarifa.Text),
                    Estado = cboEstado.SelectedItem?.ToString()
                };

                if (numeroSeleccionado.HasValue)
                {
                    habitacionService.Actualizar(habitacion);
                    MessageBox.Show("Habitación actualizada correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    habitacionService.Crear(habitacion);
                    MessageBox.Show("Habitación creada correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimpiarFormulario();
                CargarLista(null, null);
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
            if (!numeroSeleccionado.HasValue)
            {
                MessageBox.Show("Seleccione una habitación de la lista primero.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro que desea eliminar la habitación " + numeroSeleccionado.Value + "?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            try
            {
                habitacionService.Eliminar(numeroSeleccionado.Value);
                MessageBox.Show("Habitación eliminada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarLista(null, null);
            }
            catch (Hotel.Negocio_.HabitacionException ex)
            {
                MessageBox.Show(
                    "No se puede eliminar la habitación " + ex.NumeroHabitacion + " porque está ocupada.",
                    "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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