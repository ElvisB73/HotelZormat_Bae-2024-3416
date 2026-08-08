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

// TODO: revisar si System.Linq, System.Management.Instrumentation, System.Text y
// System.Threading.Tasks realmente se usan en este archivo — a simple vista no se
// ve ningún LINQ, StringBuilder, ni código async, así que podrían sobrar.

namespace Hotel.Negocio_.DaL
{
    public class HabitacionDAL
    {
        private string connectionString =
            ConfigurationManager.ConnectionStrings["HotelBae"].ConnectionString;

        // TODO: Método normal (de instancia). Usa bloque using + while (reader.Read()) para recorrer todos los resultados.
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

        // TODO: Método normal (de instancia). Usa bloque using + while (reader.Read()) para recorrer todos los resultados.
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

        // TODO: Método normal (de instancia). Usa bloque using + 1 if (reader.Read()) para saber si encontró algo.
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

            return null;
        }

        // TODO: Método normal (de instancia). Usa bloque using + 4 if independientes (piso.HasValue x2, estado no vacío x2,
        // para armar el WHERE dinámico y luego agregar los parámetros) + while (reader.Read()).
        public List<Habitacion> ObtenerConFiltros(int? piso, string estado)
        {
            List<Habitacion> lista = new List<Habitacion>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
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

        // TODO: Método normal (de instancia). Usa un bloque using. Sin if/for/while.
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

        // TODO: Método normal (de instancia). Usa un bloque using. Sin if/for/while.
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

        // TODO: Método normal (de instancia). Usa un bloque using. Sin if/for/while.
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

        // TODO: Método normal (de instancia). Usa un bloque using. Sin if/for/while.
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

        // TODO: Método normal PRIVADO (de instancia, solo se usa dentro de esta clase). Sin estructuras de control, solo arma y retorna un objeto.
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