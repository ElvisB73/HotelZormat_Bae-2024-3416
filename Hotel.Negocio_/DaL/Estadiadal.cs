// Cedula: 402444623662
using Hotel.Negocio_.Modelo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Hotel.Negocio_.DaL
{
    public class EstadiaDAL
    {
        private string connectionString =
            ConfigurationManager.ConnectionStrings["HotelBae"].ConnectionString;

        // TODO: Método normal (de instancia). Usa un bloque using. Sin if/for/while.
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

        // TODO: Método normal (de instancia). Usa un bloque using. Sin if/for/while.
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

        // TODO: Método normal (de instancia). Usa bloque using + 1 if (reader.Read()) para saber si encontró algo.
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

        // TODO: Método normal (de instancia). Usa bloque using + while (reader.Read()) para recorrer todos los resultados.
        public List<Estadia> ObtenerTodasActivas()
        {
            List<Estadia> lista = new List<Estadia>();

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

        // TODO: Método normal (de instancia). Usa bloque using + 1 if (reader.Read()) para saber si encontró algo.
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

        // TODO: Método normal PRIVADO (de instancia, solo se usa dentro de esta clase). Sin estructuras de control, solo retorna un string.
        private string ConsultaBaseConJoin()
        {
            return "SELECT E.ESTADIAID, E.RESERVAID, E.HABITACIONID, E.HUESPEDID, " +
                   "E.FECHACHECKINREAL, E.FECHACHECKOUTREAL, E.ESTADO, " +
                   "H.NUMERO AS NUMEROHABITACION, H.TARIFABASE, HU.NOMBRE, HU.APELLIDO " +
                   "FROM ESTADIAS E " +
                   "INNER JOIN HABITACIONES H ON E.HABITACIONID = H.HABITACIONID " +
                   "INNER JOIN HUESPEDES HU ON E.HUESPEDID = HU.HUESPEDID";
        }

        // TODO: Método normal PRIVADO (de instancia, solo se usa dentro de esta clase). Usa 1 operador ternario (para FechaCheckOutReal, que puede ser nula).
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