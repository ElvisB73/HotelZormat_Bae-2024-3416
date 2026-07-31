// Cedula: 402444623662
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Hotel.Negocio_.DaL
{
    public class ReporteDAL
    {
        // Lee el connection string del App.config (nombre "HotelBae")
        private string connectionString =
            ConfigurationManager.ConnectionStrings["HotelBae"].ConnectionString;

        // ── Reporte: Ocupación del día ────────────────────────────────
        // Lista las habitaciones actualmente ocupadas, junto con el
        // nombre del huésped y desde cuándo está en la habitación.
        // Se basa en la Estadia activa de cada habitación, no en la
        // fecha de hoy, porque una estadía puede llevar varios días.
        public List<Dictionary<string, object>> ObtenerOcupacionDelDia()
        {
            List<Dictionary<string, object>> lista = new List<Dictionary<string, object>>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT H.NUMERO, H.PISO, H.TIPO, HU.NOMBRE, HU.APELLIDO, " +
                                "E.FECHACHECKINREAL " +
                                "FROM HABITACIONES H " +
                                "INNER JOIN ESTADIAS E ON H.HABITACIONID = E.HABITACIONID AND E.ESTADO = 'Activa' " +
                                "INNER JOIN HUESPEDES HU ON E.HUESPEDID = HU.HUESPEDID " +
                                "WHERE H.ESTADO = 'Ocupada' " +
                                "ORDER BY H.NUMERO";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Dictionary<string, object> fila = new Dictionary<string, object>();
                    fila["Numero"] = reader["NUMERO"];
                    fila["Piso"] = reader["PISO"];
                    fila["Tipo"] = reader["TIPO"];
                    fila["Huesped"] = reader["NOMBRE"].ToString() + " " + reader["APELLIDO"].ToString();
                    fila["CheckIn"] = reader["FECHACHECKINREAL"];
                    lista.Add(fila);
                }
            }

            return lista;
        }
    }
}