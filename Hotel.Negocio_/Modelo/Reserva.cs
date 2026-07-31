using System;

namespace Hotel.Negocio_.Modelo
{
    public class Reserva
    {
        public int Id { get; set; }
        public int HabitacionId { get; set; }
        public int HuespedId { get; set; }

        public DateTime FechaCheckIn { get; set; }
        public DateTime FechaCheckOut { get; set; }

        public string Temporada { get; set; }   // "Alta", "Media" o "Baja"
        public int TotalNoches { get; set; }
        public decimal MontoTotal { get; set; }
        public string Estado { get; set; }      // "Pendiente", "Confirmada" o "Cancelada"

        // ── Campos solo de lectura, no se guardan en la tabla Reservas ──
        // Se llenan con un JOIN cuando se listan las reservas, para no
        // tener que hacer una consulta aparte solo para mostrar el
        // número de habitación o el nombre del huésped en la UI.
        public int NumeroHabitacion { get; set; }
        public string NombreHuesped { get; set; }

        // ── Calcula las noches entre check-in y check-out ────────────
        public int CalcularNoches()
        {
            return (FechaCheckOut - FechaCheckIn).Days;
        }
    }
}