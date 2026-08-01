// Cedula: 402444623662
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Hotel.Negocio_.DaL
{
    public class BitacoraDAL
    {
        // Lee el connection string del App.config (nombre "HotelBae")
        private string connectionString =
            ConfigurationManager.ConnectionStrings["HotelBae"].ConnectionString;

        // ── Registra una acción crítica: login, check-in, check-out, facturación ──
        public void Registrar(int usuarioId, string accion, string detalle)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO BITACORA (USUARIOID, ACCION, DETALLE) " +
                                "VALUES (@UsuarioId, @Accion, @Detalle)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                cmd.Parameters.AddWithValue("@Accion", accion);
                cmd.Parameters.AddWithValue("@Detalle",
                    string.IsNullOrEmpty(detalle) ? (object)DBNull.Value : detalle);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ── Trae todo el historial, más reciente primero ──────────────
        // Solo la UI del rol Administrador debe llamar este método.
        public List<Dictionary<string, object>> ObtenerTodo()
        {
            List<Dictionary<string, object>> lista = new List<Dictionary<string, object>>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT B.FECHAHORA, U.NOMBREUSUARIO, B.ACCION, B.DETALLE " +
                                "FROM BITACORA B " +
                                "INNER JOIN USUARIOS U ON B.USUARIOID = U.USUARIOID " +
                                "ORDER BY B.FECHAHORA DESC";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Dictionary<string, object> fila = new Dictionary<string, object>();
                    fila["FechaHora"] = reader["FECHAHORA"];
                    fila["Usuario"] = reader["NOMBREUSUARIO"];
                    fila["Accion"] = reader["ACCION"];
                    fila["Detalle"] = reader["DETALLE"] == DBNull.Value ? "" : reader["DETALLE"];
                    lista.Add(fila);
                }
            }

            return lista;
        }
    }
}