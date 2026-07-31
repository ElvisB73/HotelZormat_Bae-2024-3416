// Cedula: 402444623662
namespace Hotel.Negocio_.Modelo
{
    /// <summary>
    /// Constantes con los valores EXACTOS que acepta la base de datos
    /// (coinciden con los CHECK de script_bd.sql). Usar siempre estas
    /// constantes en vez de escribir el texto a mano, para no volver a
    /// tener problemas de mayúsculas/minúsculas entre la UI y la BD.
    /// </summary>
    public static class EstadosHabitacion
    {
        public const string Disponible = "Disponible";
        public const string Ocupada = "Ocupada";
        public const string Reservada = "Reservada";
        public const string Limpieza = "Limpieza";
    }

    public static class EstadosReserva
    {
        public const string Pendiente = "Pendiente";
        public const string Confirmada = "Confirmada";
        public const string Cancelada = "Cancelada";
    }

    public static class EstadosEstadia
    {
        public const string Activa = "Activa";
        public const string Cerrada = "Cerrada";
    }

    public static class Temporadas
    {
        public const string Alta = "Alta";
        public const string Media = "Media";
        public const string Baja = "Baja";
    }

    public static class Roles
    {
        public const string Administrador = "Administrador";
        public const string Recepcionista = "Recepcionista";
    }

    public static class TiposDocumento
    {
        public const string Cedula = "Cedula";
        public const string Pasaporte = "Pasaporte";
    }

    public static class TiposHabitacion
    {
        public const string Sencilla = "Sencilla";
        public const string Doble = "Doble";
        public const string Suite = "Suite";
    }
}