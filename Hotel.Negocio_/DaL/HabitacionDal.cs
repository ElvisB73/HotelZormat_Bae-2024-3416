// Cedula: 402444623662
using Hotel.Negocio_.Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Negocio_.DaL
{
    public class HabitacionDAL
    {
        // Lee el connection string del App.config (nombre "HotelBae")
        private string connectionString =
            ConfigurationManager.ConnectionStrings["HotelBae"].ConnectionString;

        // ── Trae todas las habitaciones ──────────────────────────────
        public List<Habitacion> ObtenerTodas()
        {
            List<Habitacion> lista = new List<Habitacion>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT HABITACIONID, NUMERO, TIPO, PISO, ESTADO, CAPACIDAD, TARIFABASE FROM HABITACIONES ORDER BY NUMERO";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(MapearHabitacion(reader));
                }
            }

            return lista;
        }

        // ── Trae solo las habitaciones de un piso ───────────────────
        public List<Habitacion> ObtenerPorPiso(int piso)
        {
            List<Habitacion> lista = new List<Habitacion>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT HABITACIONID, NUMERO, TIPO, PISO, ESTADO, CAPACIDAD, TARIFABASE FROM HABITACIONES WHERE PISO = @Piso ORDER BY NUMERO";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Piso", piso);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(MapearHabitacion(reader));
                }
            }

            return lista;
        }

        // ── Busca una habitación por número ─────────────────────────
        public Habitacion BuscarPorNumero(int numero)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT HABITACIONID, NUMERO, TIPO, PISO, ESTADO, CAPACIDAD, TARIFABASE FROM HABITACIONES WHERE NUMERO = @Numero";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Numero", numero);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    return MapearHabitacion(reader);
            }

            return null; // No encontrada
        }

        // ── Lista con filtros opcionales por piso y por estado ───────
        // Si piso es null, no filtra por piso. Si estado es null o vacío, no filtra por estado.
        public List<Habitacion> ObtenerConFiltros(int? piso, string estado)
        {
            List<Habitacion> lista = new List<Habitacion>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Armamos el WHERE dinámicamente, pero siempre con parámetros,
                // nunca concatenando el valor directo en el texto del query.
                string query = "SELECT HABITACIONID, NUMERO, TIPO, PISO, ESTADO, CAPACIDAD, TARIFABASE " +
                                "FROM HABITACIONES WHERE 1 = 1";

                if (piso.HasValue)
                    query += " AND PISO = @Piso";

                if (!string.IsNullOrEmpty(estado))
                    query += " AND ESTADO = @Estado";

                query += " ORDER BY NUMERO";

                SqlCommand cmd = new SqlCommand(query, con);

                if (piso.HasValue)
                    cmd.Parameters.AddWithValue("@Piso", piso.Value);

                if (!string.IsNullOrEmpty(estado))
                    cmd.Parameters.AddWithValue("@Estado", estado);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(MapearHabitacion(reader));
                }
            }

            return lista;
        }

        // ── Actualiza el estado de una habitación ───────────────────
        public void ActualizarEstado(int numero, string nuevoEstado)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE HABITACIONES SET ESTADO = @Estado WHERE NUMERO = @Numero";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Estado", nuevoEstado);
                cmd.Parameters.AddWithValue("@Numero", numero);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ── Crea una habitación nueva ─────────────────────────────
        public void Insertar(Habitacion habitacion)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO HABITACIONES (NUMERO, TIPO, PISO, CAPACIDAD, TARIFABASE, ESTADO) " +
                                "VALUES (@Numero, @Tipo, @Piso, @Capacidad, @TarifaBase, @Estado)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Numero", habitacion.Numero);
                cmd.Parameters.AddWithValue("@Tipo", habitacion.Tipo);
                cmd.Parameters.AddWithValue("@Piso", habitacion.Piso);
                cmd.Parameters.AddWithValue("@Capacidad", habitacion.Capacidad);
                cmd.Parameters.AddWithValue("@TarifaBase", habitacion.Tarifa);
                cmd.Parameters.AddWithValue("@Estado", habitacion.Estado);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ── Actualiza tipo, capacidad, tarifa y estado de una habitación ──
        // (a diferencia de ActualizarEstado, que solo cambia el estado)
        public void ActualizarCompleto(Habitacion habitacion)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE HABITACIONES SET TIPO = @Tipo, CAPACIDAD = @Capacidad, " +
                                "TARIFABASE = @TarifaBase, ESTADO = @Estado WHERE NUMERO = @Numero";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Tipo", habitacion.Tipo);
                cmd.Parameters.AddWithValue("@Capacidad", habitacion.Capacidad);
                cmd.Parameters.AddWithValue("@TarifaBase", habitacion.Tarifa);
                cmd.Parameters.AddWithValue("@Estado", habitacion.Estado);
                cmd.Parameters.AddWithValue("@Numero", habitacion.Numero);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ── Elimina una habitación por número ────────────────────────
        public void Eliminar(int numero)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM HABITACIONES WHERE NUMERO = @Numero";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Numero", numero);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ── Mapea un registro del reader a un objeto Habitacion ──────
        private Habitacion MapearHabitacion(SqlDataReader reader)
        {
            return new Habitacion
            {
                Id = Convert.ToInt32(reader["HABITACIONID"]),
                Numero = Convert.ToInt32(reader["NUMERO"]),
                Tipo = reader["TIPO"].ToString(),
                Piso = Convert.ToInt32(reader["PISO"]),
                Estado = reader["ESTADO"].ToString(),
                Capacidad = Convert.ToInt32(reader["CAPACIDAD"]),
                Tarifa = Convert.ToDecimal(reader["TARIFABASE"])
            };
        }
    }
}
