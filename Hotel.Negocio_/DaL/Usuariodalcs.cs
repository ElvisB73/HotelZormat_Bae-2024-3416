using Hotel.Negocio_.Modelo;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Hotel.Negocio_.DaL
{
    public class UsuarioDAL
    {
        // Lee el connection string del App.config (nombre "HotelBae")
        private string connectionString =
            ConfigurationManager.ConnectionStrings["HotelBae"].ConnectionString;

        // ── Busca un usuario activo por su nombre de usuario ─────────
        // Se usa en el login: primero se busca el usuario, y luego en la
        // capa de Negocio se compara el hash de la contraseña ingresada
        // contra el ContrasenaHash que devuelve este método.
        public Usuario BuscarPorNombreUsuario(string nombreUsuario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT USUARIOID, NOMBREUSUARIO, CONTRASENAHASH, NOMBRECOMPLETO, ROL, ACTIVO " +
                                "FROM USUARIOS WHERE NOMBREUSUARIO = @NombreUsuario AND ACTIVO = 1";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    return MapearUsuario(reader);
            }

            return null; // No encontrado o inactivo
        }

        // ── Mapea un registro del reader a un objeto Usuario ─────────
        private Usuario MapearUsuario(SqlDataReader reader)
        {
            return new Usuario
            {
                Id = Convert.ToInt32(reader["USUARIOID"]),
                NombreUsuario = reader["NOMBREUSUARIO"].ToString(),
                ContrasenaHash = reader["CONTRASENAHASH"].ToString(),
                NombreCompleto = reader["NOMBRECOMPLETO"].ToString(),
                Rol = reader["ROL"].ToString(),
                Activo = Convert.ToBoolean(reader["ACTIVO"])
            };
        }
    }
}