// Cedula: 402444623662
using Hotel.Negocio_.Modelo;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Hotel.Negocio_.DaL
{
    public class EstadiaDAL
    {
        // Lee el connection string del App.config (nombre "HotelBae")
        private string connectionString =
            ConfigurationManager.ConnectionStrings["HotelBae"].ConnectionString;

        // ── Crea la estadía cuando se hace el check-in real ──────────
        public int Insertar(Estadia estadia)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ESTADIAS (RESERVAID, HABITACIONID, HUESPEDID, FECHACHECKINREAL, ESTADO) " +
                                "VALUES (@ReservaId, @HabitacionId, @HuespedId, @FechaCheckInReal, 'Activa'); " +
                                "SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ReservaId", estadia.ReservaId);
                cmd.Parameters.AddWithValue("@HabitacionId", estadia.HabitacionId);
                cmd.Parameters.AddWithValue("@HuespedId", estadia.HuespedId);
                cmd.Parameters.AddWithValue("@FechaCheckInReal", estadia.FechaCheckInReal);
                con.Open();
                object nuevoId = cmd.ExecuteScalar();
                return Convert.ToInt32(nuevoId);
            }
        }

        // ── Cierra la estadía cuando se hace el check-out ────────────
        public void Cerrar(int estadiaId, DateTime fechaCheckOutReal)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE ESTADIAS SET FECHACHECKOUTREAL = @FechaCheckOutReal, ESTADO = 'Cerrada' " +
                                "WHERE ESTADIAID = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FechaCheckOutReal", fechaCheckOutReal);
                cmd.Parameters.AddWithValue("@Id", estadiaId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ── Busca una estadía por Id, con los datos de habitación ────
        // y huésped ya incluidos (JOIN), para no hacer consultas aparte.
        public Estadia BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = ConsultaBaseConJoin() + " WHERE E.ESTADIAID = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    return MapearEstadia(reader);
            }

            return null;
        }

        // ── Trae TODAS las estadías activas (todas las habitaciones ────
        // ocupadas ahora mismo), para mostrarlas en la lista de check-out.
        public System.Collections.Generic.List<Estadia> ObtenerTodasActivas()
        {
            System.Collections.Generic.List<Estadia> lista = new System.Collections.Generic.List<Estadia>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = ConsultaBaseConJoin() + " WHERE E.ESTADO = 'Activa'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(MapearEstadia(reader));
                }
            }

            return lista;
        }

        // ── Busca la estadía activa de una habitación (si tiene) ─────
        // Se usa al hacer check-out: primero hay que saber cuál es la
        // estadía activa de esa habitación antes de poder cerrarla.
        public Estadia BuscarActivaPorHabitacion(int habitacionId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = ConsultaBaseConJoin() +
                                " WHERE E.HABITACIONID = @HabitacionId AND E.ESTADO = 'Activa'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@HabitacionId", habitacionId);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    return MapearEstadia(reader);
            }

            return null;
        }

        // ── SELECT base con JOIN a Habitaciones y Huespedes ──────────
        private string ConsultaBaseConJoin()
        {
            return "SELECT E.ESTADIAID, E.RESERVAID, E.HABITACIONID, E.HUESPEDID, " +
                   "E.FECHACHECKINREAL, E.FECHACHECKOUTREAL, E.ESTADO, " +
                   "H.NUMERO AS NUMEROHABITACION, H.TARIFABASE, HU.NOMBRE, HU.APELLIDO " +
                   "FROM ESTADIAS E " +
                   "INNER JOIN HABITACIONES H ON E.HABITACIONID = H.HABITACIONID " +
                   "INNER JOIN HUESPEDES HU ON E.HUESPEDID = HU.HUESPEDID";
        }

        // ── Mapea un registro del reader a un objeto Estadia ─────────
        private Estadia MapearEstadia(SqlDataReader reader)
        {
            return new Estadia
            {
                Id = Convert.ToInt32(reader["ESTADIAID"]),
                ReservaId = Convert.ToInt32(reader["RESERVAID"]),
                HabitacionId = Convert.ToInt32(reader["HABITACIONID"]),
                HuespedId = Convert.ToInt32(reader["HUESPEDID"]),
                FechaCheckInReal = Convert.ToDateTime(reader["FECHACHECKINREAL"]),
                FechaCheckOutReal = reader["FECHACHECKOUTREAL"] == DBNull.Value
                    ? (DateTime?)null
                    : Convert.ToDateTime(reader["FECHACHECKOUTREAL"]),
                Estado = reader["ESTADO"].ToString(),
                NumeroHabitacion = Convert.ToInt32(reader["NUMEROHABITACION"]),
                TarifaHabitacion = Convert.ToDecimal(reader["TARIFABASE"]),
                NombreHuesped = reader["NOMBRE"].ToString() + " " + reader["APELLIDO"].ToString()
            };
        }
    }
}