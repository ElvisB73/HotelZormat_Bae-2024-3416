// Cedula: 402444623662
using Hotel.Negocio_.Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Hotel.Negocio_.DaL
{
    public class ReservaDAL
    {
        private string connectionString =
            ConfigurationManager.ConnectionStrings["HotelBae"].ConnectionString;

        // TODO: Método normal (de instancia). Usa un bloque using (para cerrar la conexión automáticamente). Sin if/for/while.
        public int Insertar(Reserva reserva)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO RESERVAS (HABITACIONID, HUESPEDID, FECHACHECKIN, FECHACHECKOUT, " +
                                "TEMPORADA, TOTALNOCHES, MONTOTOTAL, ESTADO) " +
                                "VALUES (@HabitacionId, @HuespedId, @FechaCheckIn, @FechaCheckOut, " +
                                "@Temporada, @TotalNoches, @MontoTotal, @Estado); " +
                                "SELECT SCOPE_IDENTITY();";

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

        // TODO: Método normal (de instancia). Usa bloque using + 1 if (reader.Read()) para saber si encontró algo.
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

            return null;
        }

        // TODO: Método normal (de instancia). Usa bloque using + while (reader.Read()) para recorrer todos los resultados.
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

        // TODO: Método normal (de instancia). Usa bloque using + while (reader.Read()) para recorrer todos los resultados.
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

        // TODO: Método normal (de instancia). Usa un bloque using. Sin if/for/while.
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

        // TODO: Método normal PRIVADO (de instancia, solo se usa dentro de esta clase). Sin estructuras de control, solo retorna un string.
        private string ConsultaBaseConJoin()
        {
            return "SELECT R.RESERVAID, R.HABITACIONID, R.HUESPEDID, R.FECHACHECKIN, R.FECHACHECKOUT, " +
                   "R.TEMPORADA, R.TOTALNOCHES, R.MONTOTOTAL, R.ESTADO, " +
                   "H.NUMERO AS NUMEROHABITACION, HU.NOMBRE, HU.APELLIDO " +
                   "FROM RESERVAS R " +
                   "INNER JOIN HABITACIONES H ON R.HABITACIONID = H.HABITACIONID " +
                   "INNER JOIN HUESPEDES HU ON R.HUESPEDID = HU.HUESPEDID";
        }

        // TODO: Método normal PRIVADO (de instancia, solo se usa dentro de esta clase). Sin estructuras de control, solo arma y retorna un objeto.
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