// Cedula: 402444623662
using Hotel.Negocio_;
using Hotel.Negocio_.DaL;
using Hotel.Negocio_.Modelo;
using System;
using System.Collections.Generic;

namespace HotelZormat.Negocio.Servicios
{
    public class ReservaService
    {
        private ReservaDAL reservaDal = new ReservaDAL();
        private HabitacionDAL habitacionDal = new HabitacionDAL();

        // TODO: Método normal (de instancia), no estático ni virtual. Usa if / else anidado.
        public bool ValidarTipoHabitacion(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo))
            {
                return false;
            }

            if (tipo == TiposHabitacion.Sencilla || tipo == TiposHabitacion.Doble || tipo == TiposHabitacion.Suite)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // TODO: Método normal (de instancia). Usa switch con 3 casos y un default.
        public decimal ObtenerDescuentoPorTemporada(string temporada)
        {
            decimal factor;

            switch (temporada)
            {
                case Temporadas.Baja:
                    factor = 0.20m;
                    break;

                case Temporadas.Media:
                    factor = 0.10m;
                    break;

                case Temporadas.Alta:
                    factor = 0m;
                    break;

                default:
                    throw new ArgumentException("Temporada desconocida: " + temporada);
            }

            return factor;
        }

        // TODO: Método normal (de instancia). Usa 2 if independientes (no anidados).
        public void ValidarFechas(DateTime fechaCheckIn, DateTime fechaCheckOut)
        {
            if (fechaCheckOut <= fechaCheckIn)
            {
                throw new FormatException("La fecha de check-out debe ser posterior a la fecha de check-in.");
            }

            if (fechaCheckIn < DateTime.Today)
            {
                throw new FormatException("La fecha de check-in no puede ser en el pasado.");
            }
        }

        // TODO: Método normal (de instancia). Sin estructuras de control, solo un return con una operación aritmética.
        public int CalcularNoches(DateTime fechaCheckIn, DateTime fechaCheckOut)
        {
            return (fechaCheckOut - fechaCheckIn).Days;
        }

        // TODO: Método normal (de instancia). Sin estructuras de control, solo cálculos y una llamada a otro método.
        public decimal CalcularMontoTotal(decimal tarifaBase, int noches, string temporada)
        {
            decimal descuento = ObtenerDescuentoPorTemporada(temporada);
            decimal tarifaConDescuento = tarifaBase - (tarifaBase * descuento);
            return tarifaConDescuento * noches;
        }

        // TODO: Método normal (de instancia). Usa 2 if para validar antes de continuar (guard clauses).
        public int CrearReserva(int numeroHabitacion, int huespedId, DateTime fechaCheckIn,
            DateTime fechaCheckOut, string temporada)
        {
            ValidarFechas(fechaCheckIn, fechaCheckOut);

            Habitacion habitacion = habitacionDal.BuscarPorNumero(numeroHabitacion);
            if (habitacion == null)
            {
                throw new FormatException("La habitación indicada no existe.");
            }

            if (!habitacion.EstaDisponible())
            {
                throw new HabitacionException(habitacion.Numero);
            }

            int noches = CalcularNoches(fechaCheckIn, fechaCheckOut);
            decimal montoTotal = CalcularMontoTotal(habitacion.Tarifa, noches, temporada);

            Reserva reserva = new Reserva
            {
                HabitacionId = habitacion.Id,
                HuespedId = huespedId,
                FechaCheckIn = fechaCheckIn,
                FechaCheckOut = fechaCheckOut,
                Temporada = temporada,
                TotalNoches = noches,
                MontoTotal = montoTotal,
                Estado = EstadosReserva.Pendiente
            };

            int nuevoId = reservaDal.Insertar(reserva);

            habitacionDal.ActualizarEstado(habitacion.Numero, EstadosHabitacion.Reservada);

            return nuevoId;
        }

        // TODO: Método normal (de instancia). Sin estructuras de control, solo delega al DAL.
        public List<Reserva> ObtenerProximas7Dias()
        {
            return reservaDal.ObtenerProximas7Dias();
        }

        // TODO: Método normal (de instancia). Usa 2 if para validar antes de continuar (guard clauses).
        public void ConfirmarReserva(int reservaId)
        {
            Reserva reserva = reservaDal.BuscarPorId(reservaId);
            if (reserva == null)
            {
                throw new FormatException("La reserva indicada no existe.");
            }

            if (reserva.Estado != EstadosReserva.Pendiente)
            {
                throw new FormatException("Solo se puede confirmar una reserva que esté Pendiente.");
            }

            reservaDal.CambiarEstado(reservaId, EstadosReserva.Confirmada);
        }

        // TODO: Método normal (de instancia). Usa 2 if para validar antes de continuar (guard clauses).
        public void CancelarReserva(int reservaId)
        {
            Reserva reserva = reservaDal.BuscarPorId(reservaId);
            if (reserva == null)
            {
                throw new FormatException("La reserva indicada no existe.");
            }

            if (reserva.Estado == EstadosReserva.Cancelada)
            {
                throw new FormatException("Esta reserva ya está cancelada.");
            }

            reservaDal.CambiarEstado(reservaId, EstadosReserva.Cancelada);

            habitacionDal.ActualizarEstado(reserva.NumeroHabitacion, EstadosHabitacion.Disponible);
        }

        // TODO: Método normal (de instancia). Usa if (validación) + for (bucle contador de 1 a noches). Posible código sin usar, verificar.
        public List<string> GenerarLineasFactura(int noches, decimal tarifaPorNoche)
        {
            var lineas = new List<string>();

            if (noches <= 0)
            {
                return lineas;
            }

            for (int i = 1; i <= noches; i++)
            {
                string linea = "Noche " + i + ": RD$ " + tarifaPorNoche;
                lineas.Add(linea);
            }

            return lineas;
        }

        // TODO: Método normal (de instancia). Usa if (validación) + foreach + if interno + break. Posible código sin usar, verificar.
        public Habitacion BuscarPrimeraDisponible(
            List<Habitacion> habitaciones,
            int capacidadMinima)
        {
            if (habitaciones == null)
            {
                return null;
            }

            Habitacion encontrada = null;

            foreach (var hab in habitaciones)
            {
                if (hab.EstaDisponible() && hab.Capacidad >= capacidadMinima)
                {
                    encontrada = hab;
                    break;
                }
            }

            return encontrada;
        }
    }
}