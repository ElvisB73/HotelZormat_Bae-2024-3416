using Hotel.Negocio_.DaL;
using Hotel.Negocio_.Modelo;
using System;
using System.Security.Cryptography;
using System.Text;

namespace HotelZormat.Negocio.Servicios
{
    /// <summary>
    /// Servicio de login y manejo de contraseñas.
    /// La UI llama a este servicio, nunca al UsuarioDAL directamente,
    /// y nunca compara contraseñas en texto plano.
    /// </summary>
    public class UsuarioService
    {
        private UsuarioDAL usuarioDal = new UsuarioDAL();

        // ── Calcula el hash SHA256 de un texto, en hexadecimal ────────
        public string CalcularHash(string textoPlano)
        {
            if (textoPlano == null)
            {
                textoPlano = string.Empty;
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(textoPlano);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                StringBuilder resultado = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    resultado.Append(b.ToString("x2"));
                }

                return resultado.ToString();
            }
        }

        // ── Valida el login: busca el usuario y compara el hash ──────
        // Devuelve el Usuario si la contraseña es correcta, o null si
        // el usuario no existe o la contraseña está mal. La UI decide
        // qué mensaje mostrar según si el resultado es null o no.
        public Usuario ValidarLogin(string nombreUsuario, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                throw new FormatException("Debe ingresar usuario y contraseña.");
            }

            Usuario usuario = usuarioDal.BuscarPorNombreUsuario(nombreUsuario);

            if (usuario == null)
            {
                return null; // Usuario no existe o está inactivo
            }

            string hashIngresado = CalcularHash(contrasena);

            if (hashIngresado != usuario.ContrasenaHash)
            {
                return null; // Contraseña incorrecta
            }

            return usuario; // Login correcto
        }
    }
}