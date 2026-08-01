// Cedula: 402444623662
using Hotel.Negocio_.DaL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelZormat
{
    public partial class FrmBitacora : Form
    {
        private BitacoraDAL bitacoraDal = new BitacoraDAL();

        public FrmBitacora()
        {
            InitializeComponent();
        }

        private void FrmBitacora_Load(object sender, EventArgs e)
        {
            // Verificación de rol por si alguien abre este formulario
            // directamente, sin pasar por el botón oculto del Dashboard.
            if (!SesionActual.EsAdministrador())
            {
                MessageBox.Show("Solo el Administrador puede consultar la bitácora.", "Acceso restringido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            lstBitacora.View = View.Details;
            lstBitacora.Columns.Clear();
            lstBitacora.Columns.Add("Fecha/Hora", 140);
            lstBitacora.Columns.Add("Usuario", 100);
            lstBitacora.Columns.Add("Acción", 100);
            lstBitacora.Columns.Add("Detalle", 260);

            CargarBitacora();
        }

        private void CargarBitacora()
        {
            try
            {
                lstBitacora.Items.Clear();

                foreach (Dictionary<string, object> fila in bitacoraDal.ObtenerTodo())
                {
                    ListViewItem item = new ListViewItem(Convert.ToDateTime(fila["FechaHora"]).ToString("dd/MM HH:mm"));
                    item.SubItems.Add(fila["Usuario"].ToString());
                    item.SubItems.Add(fila["Accion"].ToString());
                    item.SubItems.Add(fila["Detalle"].ToString());
                    lstBitacora.Items.Add(item);
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarBitacora();
        }
    }
}