// Cedula: 402444623662
using Hotel.Negocio_.Modelo;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Hotel.Negocio_.DaL
{
    public class FacturaDAL
    {
        private string connectionString =
            ConfigurationManager.ConnectionStrings["HotelBae"].ConnectionString;

        private const string TIPO_NCF = "B02";

        // TODO: Método normal (de instancia). Usa bloque using + try/catch (con Rollback si algo falla) + una transacción SQL.
        public string GenerarSiguienteNCF()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction transaccion = con.BeginTransaction();

                try
                {
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

                    return TIPO_NCF + nuevoNumero.ToString("D10");
                }
                catch
                {
                    transaccion.Rollback();
                    throw;
                }
            }
        }

        // TODO: Método normal (de instancia). Usa un bloque using. Sin if/for/while.
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

        // TODO: Método normal (de instancia). Usa un bloque using. Sin if/for/while.
        public decimal ObtenerIngresosPorRango(DateTime desde, DateTime hasta)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT ISNULL(SUM(TOTAL), 0) FROM FACTURAS " +
                                "WHERE FECHAEMISION BETWEEN @Desde AND @Hasta";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Desde", desde);
                cmd.Parameters.AddWithValue("@Hasta", hasta.AddDays(1).AddSeconds(-1));
                con.Open();

                object resultado = cmd.ExecuteScalar();
                return Convert.ToDecimal(resultado);
            }
        }
    }
}