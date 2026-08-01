// Cedula: 402444623662
using System;

namespace Hotel.Negocio_.Modelo
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string ContrasenaHash { get; set; }
        public string NombreCompleto { get; set; }
        public string Rol { get; set; }         // "Administrador" o "Recepcionista"
        public bool Activo { get; set; }

        public bool EsAdministrador()
        {
            return Rol == "Administrador";
        }
    }
}