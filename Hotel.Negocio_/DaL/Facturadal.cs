using Hotel.Negocio_.Modelo;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Hotel.Negocio_.DaL
{
    public class FacturaDAL
    {
        // Lee el connection string del App.config (nombre "HotelBae")
        private string connectionString =
            ConfigurationManager.ConnectionStrings["HotelBae"].ConnectionString;

        private const string TIPO_NCF = "B02"; // Consumo Final

        // ── Genera el siguiente número de NCF y lo guarda ────────────
        // Todo esto pasa dentro de UNA sola conexión/transacción para
        // evitar que dos facturas terminen con el mismo número si dos
        // usuarios facturan casi al mismo tiempo.
        public string GenerarSiguienteNCF()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction transaccion = con.BeginTransaction();

                try
                {
                    // Bloquea la fila mientras se lee, para que otra
                    // factura no tome el mismo número al mismo tiempo.
                    string queryLeer = "SELECT UltimoNumero FROM NumeracionNCF WITH (UPDLOCK, ROWLOCK) " +
                                        "WHERE TipoNCF = @Tipo";
                    SqlCommand cmdLeer = new SqlCommand(queryLeer, con, transaccion);
                    cmdLeer.Parameters.AddWithValue("@Tipo", TIPO_NCF);
                    int ultimoNumero = Convert.ToInt32(cmdLeer.ExecuteScalar());

                    int nuevoNumero = ultimoNumero + 1;

                    string queryActualizar = "UPDATE NumeracionNCF SET UltimoNumero = @Nuevo WHERE TipoNCF = @Tipo";
                    SqlCommand cmdActualizar = new SqlCommand(queryActualizar, con, transaccion);
                    cmdActualizar.Parameters.AddWithValue("@Nuevo", nuevoNumero);
                    cmdActualizar.Parameters.AddWithValue("@Tipo", TIPO_NCF);
                    cmdActualizar.ExecuteNonQuery();

                    transaccion.Commit();

                    // Formato NCF: B02 + 10 dígitos con ceros a la izquierda
                    return TIPO_NCF + nuevoNumero.ToString("D10");
                }
                catch
                {
                    transaccion.Rollback();
                    throw;
                }
            }
        }

        // ── Guarda la factura ya generada ─────────────────────────────
        public int Insertar(Factura factura)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO FACTURAS (ESTADIAID, NCF, SUBTOTAL, ITBIS, PROPINA, TOTAL) " +
                                "VALUES (@EstadiaId, @NCF, @Subtotal, @ITBIS, @Propina, @Total); " +
                                "SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@EstadiaId", factura.EstadiaId);
                cmd.Parameters.AddWithValue("@NCF", factura.NCF);
                cmd.Parameters.AddWithValue("@Subtotal", factura.Subtotal);
                cmd.Parameters.AddWithValue("@ITBIS", factura.ITBIS);
                cmd.Parameters.AddWithValue("@Propina", factura.Propina);
                cmd.Parameters.AddWithValue("@Total", factura.Total);
                con.Open();
                object nuevoId = cmd.ExecuteScalar();
                return Convert.ToInt32(nuevoId);
            }
        }

        // ── Suma los totales de facturas emitidas entre dos fechas ───
        // Para el reporte de "Ingresos por rango de fecha".
        public decimal ObtenerIngresosPorRango(DateTime desde, DateTime hasta)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT ISNULL(SUM(TOTAL), 0) FROM FACTURAS " +
                                "WHERE FECHAEMISION BETWEEN @Desde AND @Hasta";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Desde", desde);
                // se le suma 1 día para incluir todo el día "hasta" completo
                cmd.Parameters.AddWithValue("@Hasta", hasta.AddDays(1).AddSeconds(-1));
                con.Open();

                object resultado = cmd.ExecuteScalar();
                return Convert.ToDecimal(resultado);
            }
        }
    }
}