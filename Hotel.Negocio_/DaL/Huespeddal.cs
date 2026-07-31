using Hotel.Negocio_.Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Hotel.Negocio_.DaL
{
    public class HuespedDAL
    {
        // Lee el connection string del App.config (nombre "HotelBae")
        private string connectionString =
            ConfigurationManager.ConnectionStrings["HotelBae"].ConnectionString;

        // ── Trae todos los huéspedes ─────────────────────────────────
        public List<Huesped> ObtenerTodos()
        {
            List<Huesped> lista = new List<Huesped>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT HUESPEDID, TIPODOCUMENTO, NUMERODOCUMENTO, NOMBRE, APELLIDO, " +
                                "NACIONALIDAD, TELEFONO, EMAIL FROM HUESPEDES ORDER BY APELLIDO, NOMBRE";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(MapearHuesped(reader));
                }
            }

            return lista;
        }

        // ── Busca un huésped por su Id ───────────────────────────────
        public Huesped BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT HUESPEDID, TIPODOCUMENTO, NUMERODOCUMENTO, NOMBRE, APELLIDO, " +
                                "NACIONALIDAD, TELEFONO, EMAIL FROM HUESPEDES WHERE HUESPEDID = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    return MapearHuesped(reader);
            }

            return null; // No encontrado
        }

        // ── Busca por cédula o pasaporte exacto ──────────────────────
        public Huesped BuscarPorDocumento(string numeroDocumento)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT HUESPEDID, TIPODOCUMENTO, NUMERODOCUMENTO, NOMBRE, APELLIDO, " +
                                "NACIONALIDAD, TELEFONO, EMAIL FROM HUESPEDES WHERE NUMERODOCUMENTO = @Numero";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Numero", numeroDocumento);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    return MapearHuesped(reader);
            }

            return null; // No encontrado
        }

        // ── Busca por nombre o apellido (texto parcial) ──────────────
        // Se usa para el buscador en la UI, cuando el usuario escribe
        // solo una parte del nombre o apellido.
        public List<Huesped> BuscarPorNombre(string texto)
        {
            List<Huesped> lista = new List<Huesped>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT HUESPEDID, TIPODOCUMENTO, NUMERODOCUMENTO, NOMBRE, APELLIDO, " +
                                "NACIONALIDAD, TELEFONO, EMAIL FROM HUESPEDES " +
                                "WHERE NOMBRE LIKE @Texto OR APELLIDO LIKE @Texto " +
                                "ORDER BY APELLIDO, NOMBRE";
                SqlCommand cmd = new SqlCommand(query, con);
                // El símbolo % va dentro del valor del parámetro, no concatenado en el query.
                cmd.Parameters.AddWithValue("@Texto", "%" + texto + "%");
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(MapearHuesped(reader));
                }
            }

            return lista;
        }

        // ── Crea un huésped nuevo ─────────────────────────────────────
        public void Insertar(Huesped huesped)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO HUESPEDES (TIPODOCUMENTO, NUMERODOCUMENTO, NOMBRE, APELLIDO, " +
                                "NACIONALIDAD, TELEFONO, EMAIL) VALUES (@TipoDocumento, @NumeroDocumento, " +
                                "@Nombre, @Apellido, @Nacionalidad, @Telefono, @Email)";
                SqlCommand cmd = new SqlCommand(query, con);
                AgregarParametros(cmd, huesped);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ── Actualiza los datos de un huésped existente ──────────────
        public void Actualizar(Huesped huesped)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE HUESPEDES SET TIPODOCUMENTO = @TipoDocumento, " +
                                "NUMERODOCUMENTO = @NumeroDocumento, NOMBRE = @Nombre, APELLIDO = @Apellido, " +
                                "NACIONALIDAD = @Nacionalidad, TELEFONO = @Telefono, EMAIL = @Email " +
                                "WHERE HUESPEDID = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                AgregarParametros(cmd, huesped);
                cmd.Parameters.AddWithValue("@Id", huesped.Id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ── Elimina un huésped por Id ─────────────────────────────────
        public void Eliminar(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM HUESPEDES WHERE HUESPEDID = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ── Trae el historial de estadías de un huésped ──────────────
        // Devuelve filas simples (número de habitación, fechas) para
        // mostrarlas en un ListView o DataGridView en la UI.
        public List<Dictionary<string, object>> ObtenerHistorialEstadias(int huespedId)
        {
            List<Dictionary<string, object>> historial = new List<Dictionary<string, object>>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT H.NUMERO, E.FECHACHECKINREAL, E.FECHACHECKOUTREAL, E.ESTADO " +
                                "FROM ESTADIAS E " +
                                "INNER JOIN HABITACIONES H ON E.HABITACIONID = H.HABITACIONID " +
                                "WHERE E.HUESPEDID = @HuespedId " +
                                "ORDER BY E.FECHACHECKINREAL DESC";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@HuespedId", huespedId);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Dictionary<string, object> fila = new Dictionary<string, object>();
                    fila["Numero"] = reader["NUMERO"];
                    fila["CheckIn"] = reader["FECHACHECKINREAL"];
                    fila["CheckOut"] = reader["FECHACHECKOUTREAL"] == DBNull.Value ? null : (object)reader["FECHACHECKOUTREAL"];
                    fila["Estado"] = reader["ESTADO"];
                    historial.Add(fila);
                }
            }

            return historial;
        }

        // ── Agrega los parámetros comunes de Insertar y Actualizar ───
        private void AgregarParametros(SqlCommand cmd, Huesped huesped)
        {
            cmd.Parameters.AddWithValue("@TipoDocumento", huesped.TipoDocumento);
            cmd.Parameters.AddWithValue("@NumeroDocumento", huesped.NumeroDocumento);
            cmd.Parameters.AddWithValue("@Nombre", huesped.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", huesped.Apellido);
            // Nacionalidad puede venir vacía, en ese caso guardamos DBNull en vez de string vacío
            cmd.Parameters.AddWithValue("@Nacionalidad",
                string.IsNullOrEmpty(huesped.Nacionalidad) ? (object)DBNull.Value : huesped.Nacionalidad);
            cmd.Parameters.AddWithValue("@Telefono",
                string.IsNullOrEmpty(huesped.Telefono) ? (object)DBNull.Value : huesped.Telefono);
            cmd.Parameters.AddWithValue("@Email",
                string.IsNullOrEmpty(huesped.Email) ? (object)DBNull.Value : huesped.Email);
        }

        // ── Mapea un registro del reader a un objeto Huesped ─────────
        private Huesped MapearHuesped(SqlDataReader reader)
        {
            return new Huesped
            {
                Id = Convert.ToInt32(reader["HUESPEDID"]),
                TipoDocumento = reader["TIPODOCUMENTO"].ToString(),
                NumeroDocumento = reader["NUMERODOCUMENTO"].ToString(),
                Nombre = reader["NOMBRE"].ToString(),
                Apellido = reader["APELLIDO"].ToString(),
                Nacionalidad = reader["NACIONALIDAD"] == DBNull.Value ? "" : reader["NACIONALIDAD"].ToString(),
                Telefono = reader["TELEFONO"] == DBNull.Value ? "" : reader["TELEFONO"].ToString(),
                Email = reader["EMAIL"] == DBNull.Value ? "" : reader["EMAIL"].ToString()
            };
        }
    }
}