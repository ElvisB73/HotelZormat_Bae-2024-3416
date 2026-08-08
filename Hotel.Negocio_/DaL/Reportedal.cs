// Cedula: 402444623662
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Hotel.Negocio_.DaL
{
    public class ReporteDAL
    {
        private string connectionString =
            ConfigurationManager.ConnectionStrings["HotelBae"].ConnectionString;

        // TODO: Método normal (de instancia). Usa bloque using + while (reader.Read()) para recorrer todos los resultados.
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