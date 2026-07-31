using Hotel.Negocio_;
using Hotel.Negocio_.DaL;
using Hotel.Negocio_.Modelo;
using System;
using System.Collections.Generic;

namespace HotelZormat.Negocio.Servicios
{
    /// <summary>
    /// Servicio de validaciones y cálculos del flujo de reservas.
    /// Lab día 05 · ISW-123 · semana 02
    /// /// </summary>
    public class ReservaService
    {
        private ReservaDAL reservaDal = new ReservaDAL();
        private HabitacionDAL habitacionDal = new HabitacionDAL();

        public bool ValidarTipoHabitacion(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo))
            {
                return false;
            }

            if (tipo == "Sencilla" || tipo == "Doble" || tipo == "Suite")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Devuelve el factor a aplicar según la temporada.
        /// Positivo = descuento, negativo = recarga.
        /// Reto 02 · usa switch
        /// /// </summary>
        public decimal ObtenerDescuentoPorTemporada(string temporada)
        {
            decimal factor;

            switch (temporada)
            {
                case "Baja":
                    factor = 0.20m;
                    break;

                case "Media":
                    factor = 0.10m;
                    break;

                case "Alta":
                    factor = 0m;
                    break;

                default:
                    throw new ArgumentException("Temporada desconocida: " + temporada);
            }

            return factor;
        }
        // ── Valida que el check-out sea posterior al check-in ────────
        // Lanza FormatException para que la UI lo atrape en su catch
        // específico y muestre el mensaje con MessageBox.
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

        // ── Calcula las noches entre dos fechas ──────────────────────
        public int CalcularNoches(DateTime fechaCheckIn, DateTime fechaCheckOut)
        {
            return (fechaCheckOut - fechaCheckIn).Days;
        }

        // ── Calcula el monto total de la reserva aplicando el ────────
        // descuento de temporada sobre la tarifa base de la habitación.
        public decimal CalcularMontoTotal(decimal tarifaBase, int noches, string temporada)
        {
            decimal descuento = ObtenerDescuentoPorTemporada(temporada);
            decimal tarifaConDescuento = tarifaBase - (tarifaBase * descuento);
            return tarifaConDescuento * noches;
        }

        // ── Crea una reserva completa: valida fechas, calcula noches ──
        // y monto, y verifica que la habitación esté disponible antes
        // de guardar. Devuelve el Id de la reserva creada.
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
                Estado = "Pendiente"
            };

            int nuevoId = reservaDal.Insertar(reserva);

            // La habitación pasa a Reservada mientras se confirma
            habitacionDal.ActualizarEstado(habitacion.Numero, "Reservada");

            return nuevoId;
        }

        // ── Lista las reservas próximas 7 días ────────────────────────
        public List<Reserva> ObtenerProximas7Dias()
        {
            return reservaDal.ObtenerProximas7Dias();
        }

        /// <summary>
        /// Genera las líneas de detalle de una factura, una por noche.
        /// Devuelve una lista de strings con el formato "Noche N: RD$ tarifa".
        /// Reto 03 · usa for
        /// /// </summary>
        public List<string> GenerarLineasFactura(int noches, decimal tarifaPorNoche)
        {
            var lineas = new List<string>();

            if (noches <= 0)
            {
                return lineas;       // devuelve lista vacía
            }

            for (int i = 1; i <= noches; i++)
            {
                string linea = "Noche " + i + ": RD$ " + tarifaPorNoche;
                lineas.Add(linea);
            }

            return lineas;
        }
        /// <summary>
        /// Encuentra la primera habitación disponible con capacidad mínima.
        /// Devuelve null si no hay ninguna que cumpla.
        /// Reto 04 · usa foreach + if + break
        /// /// </summary>
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
                    break;             // ya encontramos una, no seguimos buscando
                }
            }

            return encontrada;
        }
    }
}