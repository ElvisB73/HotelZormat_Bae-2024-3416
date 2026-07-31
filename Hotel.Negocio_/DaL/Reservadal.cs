using Hotel.Negocio_.Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Hotel.Negocio_.DaL
{
    public class ReservaDAL
    {
        // Lee el connection string del App.config (nombre "HotelBae")
        private string connectionString =
            ConfigurationManager.ConnectionStrings["HotelBae"].ConnectionString;

        // ── Crea una reserva nueva ────────────────────────────────────
        // Nota: la validación de que FechaCheckOut sea mayor que
        // FechaCheckIn, y el cálculo de TotalNoches/MontoTotal, se hacen
        // en la capa de Negocio ANTES de llamar este método. Aquí solo
        // se guarda lo que ya viene validado y calculado.
        public int Insertar(Reserva reserva)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO RESERVAS (HABITACIONID, HUESPEDID, FECHACHECKIN, FECHACHECKOUT, " +
                                "TEMPORADA, TOTALNOCHES, MONTOTOTAL, ESTADO) " +
                                "VALUES (@HabitacionId, @HuespedId, @FechaCheckIn, @FechaCheckOut, " +
                                "@Temporada, @TotalNoches, @MontoTotal, @Estado); " +
                                "SELECT SCOPE_IDENTITY();"; // devuelve el Id recién creado

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@HabitacionId", reserva.HabitacionId);
                cmd.Parameters.AddWithValue("@HuespedId", reserva.HuespedId);
                cmd.Parameters.AddWithValue("@FechaCheckIn", reserva.FechaCheckIn);
                cmd.Parameters.AddWithValue("@FechaCheckOut", reserva.FechaCheckOut);
                cmd.Parameters.AddWithValue("@Temporada", reserva.Temporada);
                cmd.Parameters.AddWithValue("@TotalNoches", reserva.TotalNoches);
                cmd.Parameters.AddWithValue("@MontoTotal", reserva.MontoTotal);
                cmd.Parameters.AddWithValue("@Estado", reserva.Estado);

                con.Open();
                object nuevoId = cmd.ExecuteScalar();
                return Convert.ToInt32(nuevoId);
            }
        }

        // ── Busca una reserva por Id ──────────────────────────────────
        public Reserva BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = ConsultaBaseConJoin() + " WHERE R.RESERVAID = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    return MapearReserva(reader);
            }

            return null; // No encontrada
        }

        // ── Lista todas las reservas, más recientes primero ──────────
        public List<Reserva> ObtenerTodas()
        {
            List<Reserva> lista = new List<Reserva>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = ConsultaBaseConJoin() + " ORDER BY R.FECHACHECKIN DESC";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(MapearReserva(reader));
                }
            }

            return lista;
        }

        // ── Lista las reservas cuyo check-in cae en los próximos 7 días ──
        public List<Reserva> ObtenerProximas7Dias()
        {
            List<Reserva> lista = new List<Reserva>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = ConsultaBaseConJoin() +
                                " WHERE R.FECHACHECKIN BETWEEN @HoyInicio AND @HoyMasSiete " +
                                " AND R.ESTADO <> 'Cancelada' " +
                                " ORDER BY R.FECHACHECKIN ASC";

                SqlCommand cmd = new SqlCommand(query, con);
                // Se calculan las fechas en C# y se mandan como parámetros,
                // no se usa GETDATE() directo para poder controlar la hora exacta.
                cmd.Parameters.AddWithValue("@HoyInicio", DateTime.Today);
                cmd.Parameters.AddWithValue("@HoyMasSiete", DateTime.Today.AddDays(7));
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(MapearReserva(reader));
                }
            }

            return lista;
        }

        // ── Cambia el estado de una reserva (Pendiente/Confirmada/Cancelada) ──
        public void CambiarEstado(int reservaId, string nuevoEstado)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE RESERVAS SET ESTADO = @Estado WHERE RESERVAID = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Estado", nuevoEstado);
                cmd.Parameters.AddWithValue("@Id", reservaId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // ── SELECT base con JOIN a Habitaciones y Huespedes ──────────
        // para poder mostrar el número de habitación y el nombre del
        // huésped sin tener que hacer consultas aparte en la UI.
        private string ConsultaBaseConJoin()
        {
            return "SELECT R.RESERVAID, R.HABITACIONID, R.HUESPEDID, R.FECHACHECKIN, R.FECHACHECKOUT, " +
                   "R.TEMPORADA, R.TOTALNOCHES, R.MONTOTOTAL, R.ESTADO, " +
                   "H.NUMERO AS NUMEROHABITACION, HU.NOMBRE, HU.APELLIDO " +
                   "FROM RESERVAS R " +
                   "INNER JOIN HABITACIONES H ON R.HABITACIONID = H.HABITACIONID " +
                   "INNER JOIN HUESPEDES HU ON R.HUESPEDID = HU.HUESPEDID";
        }

        // ── Mapea un registro del reader a un objeto Reserva ─────────
        private Reserva MapearReserva(SqlDataReader reader)
        {
            return new Reserva
            {
                Id = Convert.ToInt32(reader["RESERVAID"]),
                HabitacionId = Convert.ToInt32(reader["HABITACIONID"]),
                HuespedId = Convert.ToInt32(reader["HUESPEDID"]),
                FechaCheckIn = Convert.ToDateTime(reader["FECHACHECKIN"]),
                FechaCheckOut = Convert.ToDateTime(reader["FECHACHECKOUT"]),
                Temporada = reader["TEMPORADA"].ToString(),
                TotalNoches = Convert.ToInt32(reader["TOTALNOCHES"]),
                MontoTotal = Convert.ToDecimal(reader["MONTOTOTAL"]),
                Estado = reader["ESTADO"].ToString(),
                NumeroHabitacion = Convert.ToInt32(reader["NUMEROHABITACION"]),
                NombreHuesped = reader["NOMBRE"].ToString() + " " + reader["APELLIDO"].ToString()
            };
        }
    }
}