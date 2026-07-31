using System;

namespace Hotel.Negocio_.Modelo
{
    public class Estadia
    {
        public int Id { get; set; }
        public int ReservaId { get; set; }
        public int HabitacionId { get; set; }
        public int HuespedId { get; set; }

        public DateTime FechaCheckInReal { get; set; }
        public DateTime? FechaCheckOutReal { get; set; } // null mientras está activa

        public string Estado { get; set; } // "Activa" o "Cerrada"

        // Campos solo de lectura, llenados con JOIN para mostrar en la UI
        public int NumeroHabitacion { get; set; }
        public string NombreHuesped { get; set; }
        public decimal TarifaHabitacion { get; set; }
    }
}