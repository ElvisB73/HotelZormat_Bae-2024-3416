using Hotel.Negocio_;
using Hotel.Negocio_.DaL;
using Hotel.Negocio_.Modelo;
using System;

namespace HotelZormat.Negocio.Servicios
{
    /// <summary>
    /// Servicio que coordina el flujo de check-in, check-out y facturación.
    /// La UI llama a este servicio, nunca toca los repositorios directo.
    /// </summary>
    public class EstadiaService
    {
        private const decimal PORCENTAJE_ITBIS = 0.18m;
        private const decimal PORCENTAJE_PROPINA = 0.10m;

        private EstadiaDAL estadiaDal = new EstadiaDAL();
        private HabitacionDAL habitacionDal = new HabitacionDAL();
        private ReservaDAL reservaDal = new ReservaDAL();
        private FacturaDAL facturaDal = new FacturaDAL();
        private BitacoraDAL bitacoraDal = new BitacoraDAL();

        // ── Convierte una reserva confirmada en una estadía activa ────
        // Cambia la habitación a Ocupada y registra la acción en bitácora.
        public int HacerCheckIn(int reservaId, int usuarioId)
        {
            Reserva reserva = reservaDal.BuscarPorId(reservaId);
            if (reserva == null)
            {
                throw new FormatException("La reserva indicada no existe.");
            }

            if (reserva.Estado != EstadosReserva.Confirmada)
            {
                throw new FormatException("Solo se puede hacer check-in de una reserva Confirmada.");
            }

            Estadia estadia = new Estadia
            {
                ReservaId = reserva.Id,
                HabitacionId = reserva.HabitacionId,
                HuespedId = reserva.HuespedId,
                FechaCheckInReal = DateTime.Now
            };

            int estadiaId = estadiaDal.Insertar(estadia);

            habitacionDal.ActualizarEstado(reserva.NumeroHabitacion, EstadosHabitacion.Ocupada);

            bitacoraDal.Registrar(usuarioId, "CheckIn",
                "Check-in de la habitacion " + reserva.NumeroHabitacion);

            return estadiaId;
        }

        // ── Cierra la estadía, genera la factura y libera la habitación ──
        // Devuelve la factura generada, con todos los desgloses, para
        // que la UI la muestre en pantalla.
        public Factura HacerCheckOut(int habitacionNumero, int usuarioId)
        {
            Habitacion habitacion = habitacionDal.BuscarPorNumero(habitacionNumero);
            if (habitacion == null)
            {
                throw new FormatException("La habitación indicada no existe.");
            }

            Estadia estadia = estadiaDal.BuscarActivaPorHabitacion(habitacion.Id);
            if (estadia == null)
            {
                throw new FormatException("Esta habitación no tiene una estadía activa.");
            }

            DateTime fechaCheckOut = DateTime.Now;
            estadiaDal.Cerrar(estadia.Id, fechaCheckOut);

            // Se cobra por lo menos 1 noche, aunque el check-out sea el mismo día
            int noches = Math.Max(1, (fechaCheckOut.Date - estadia.FechaCheckInReal.Date).Days);

            decimal subtotal = estadia.TarifaHabitacion * noches;
            decimal itbis = subtotal * PORCENTAJE_ITBIS;
            decimal propina = subtotal * PORCENTAJE_PROPINA;
            decimal total = subtotal + itbis + propina;

            string ncf = facturaDal.GenerarSiguienteNCF();

            Factura factura = new Factura
            {
                EstadiaId = estadia.Id,
                NCF = ncf,
                Subtotal = subtotal,
                ITBIS = itbis,
                Propina = propina,
                Total = total,
                FechaEmision = fechaCheckOut
            };

            factura.Id = facturaDal.Insertar(factura);

            // La habitación pasa a Limpieza, no directo a Disponible
            habitacionDal.ActualizarEstado(habitacionNumero, EstadosHabitacion.Limpieza);

            bitacoraDal.Registrar(usuarioId, "CheckOut",
                "Check-out de la habitacion " + habitacionNumero + ", factura " + ncf);
            bitacoraDal.Registrar(usuarioId, "Facturacion",
                "Factura " + ncf + " generada por RD$ " + total.ToString("N2"));

            return factura;
        }
    }
}