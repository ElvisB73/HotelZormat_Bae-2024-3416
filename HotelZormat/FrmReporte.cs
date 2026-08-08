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
        // TODO: antes de dar este formulario por terminado, confirma que los
        // nombres de los controles en tu Designer.cs coincidan EXACTO (mayúsculas
        // incluidas) con los usados aquí: lstOcupacion, btnActualizarOcupacion,
        // dtpDesde, dtpHasta, btnCalcularIngresos, lblIngresoTotal. Y que los
        // eventos (Load, Click) estén conectados con "+=" en el Designer, no
        // solo declarados como método suelto (ya nos pasó con otros formularios).
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
            lstOcupacion.Columns.Add("Hasta (est.)", 90);

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
                    item.SubItems.Add(Convert.ToDateTime(fila["CheckOutEstimado"]).ToShortDateString());
                    lstOcupacion.Items.Add(item);
                }

                if (ocupacion.Count == 0)
                {
                    // TODO: este MessageBox aparece cada vez que se abre el formulario
                    // (FrmReporte_Load también llama a este método) y no solo cuando
                    // el usuario pide el reporte a propósito. Si molesta en las pruebas,
                    // considerar mostrar el aviso solo dentro de btnActualizarOcupacion_Click,
                    // y en el Load simplemente dejar la lista vacía sin popup.
                    MessageBox.Show("No hay habitaciones ocupadas en este momento.", "Ocupación del día",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

                // TODO: si el total da RD$ 0.00, actualmente no se distingue entre
                // "no hubo facturas en ese rango" (caso normal) y un posible error
                // silencioso. Si se quiere ser más explícito con el usuario, se podría
                // agregar un mensaje aparte cuando total == 0.
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