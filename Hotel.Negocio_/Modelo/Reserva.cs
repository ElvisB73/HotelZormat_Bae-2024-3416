// Cedula: 402444623662
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

        public string Temporada { get; set; }   //TODO: "Alta", "Media" o "Baja"
        public int TotalNoches { get; set; }
        public decimal MontoTotal { get; set; }
        public string Estado { get; set; }      //TODO: "Pendiente", "Confirmada" o "Cancelada"
        public int NumeroHabitacion { get; set; }
        public string NombreHuesped { get; set; }

        // TODO: Calcula las noches entre check-in y check-out
        public int CalcularNoches()
        {
            return (FechaCheckOut - FechaCheckIn).Days;
        }
    }
}