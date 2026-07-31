// Cedula: 402444623662
using Hotel.Negocio_.Modelo;

namespace HotelZormat
{
    /// <summary>
    /// Guarda el usuario que inició sesión, para que cualquier formulario
    /// de la aplicación sepa quién es y qué rol tiene, sin tener que
    /// volver a pedir el login. Vive solo mientras el programa está abierto.
    /// </summary>
    public static class SesionActual
    {
        public static Usuario UsuarioLogueado { get; set; }

        public static bool EsAdministrador()
        {
            return UsuarioLogueado != null && UsuarioLogueado.Rol == Roles.Administrador;
        }
    }
}