// Cedula: 402444623662
using HotelZormat.Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelZormat
{
    public partial class FrmReporte : Form
    {
        private ReporteService reporteService = new ReporteService();

        public FrmReporte()
        {
            InitializeComponent();
        }

        private void FrmReporte_Load(object sender, EventArgs e)
        {

            lstOcupacion.View = View.Details;
            lstOcupacion.Columns.Clear();
            lstOcupacion.Columns.Add("Hab.", 60);
            lstOcupacion.Columns.Add("Piso", 50);
            lstOcupacion.Columns.Add("Tipo", 90);
            lstOcupacion.Columns.Add("Huésped", 140);
            lstOcupacion.Columns.Add("Desde", 90);

            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpHasta.Value = DateTime.Today;

            lblIngresoTotal.Text = "RD$ 0.00";

            CargarOcupacionDelDia();
        }

        // ── Reporte 1: Ocupación del día ──────────────────────────────
        private void CargarOcupacionDelDia()
        {
            try
            {
                lstOcupacion.Items.Clear();

                List<Dictionary<string, object>> ocupacion = reporteService.ObtenerOcupacionDelDia();

                foreach (Dictionary<string, object> fila in ocupacion)
                {
                    ListViewItem item = new ListViewItem(fila["Numero"].ToString());
                    item.SubItems.Add(fila["Piso"].ToString());
                    item.SubItems.Add(fila["Tipo"].ToString());
                    item.SubItems.Add(fila["Huesped"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(fila["CheckIn"]).ToShortDateString());
                    lstOcupacion.Items.Add(item);
                }

                if (ocupacion.Count == 0)
                {
                    MessageBox.Show("No hay habitaciones ocupadas en este momento.", "Ocupación del día",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnActualizarOcupacion_Click(object sender, EventArgs e)
        {
            CargarOcupacionDelDia();
        }

        // ── Reporte 2: Ingresos por rango de fecha ────────────────────
        private void btnCalcularIngresos_Click(object sender, EventArgs e)
        {
            try
            {
                decimal total = reporteService.ObtenerIngresosPorRango(dtpDesde.Value.Date, dtpHasta.Value.Date);
                lblIngresoTotal.Text = "RD$ " + total.ToString("N2");
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Rango inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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