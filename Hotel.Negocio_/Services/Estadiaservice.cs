// Cedula: 402444623662
using Hotel.Negocio_;
using Hotel.Negocio_.DaL;
using Hotel.Negocio_.Modelo;
using System;
using System.Collections.Generic;

namespace HotelZormat.Negocio.Servicios
{
    public class EstadiaService
    {
        private const decimal PORCENTAJE_ITBIS = 0.18m;
        private const decimal PORCENTAJE_PROPINA = 0.10m;

        private EstadiaDAL estadiaDal = new EstadiaDAL();
        private HabitacionDAL habitacionDal = new HabitacionDAL();
        private ReservaDAL reservaDal = new ReservaDAL();
        private FacturaDAL facturaDal = new FacturaDAL();
        private BitacoraDAL bitacoraDal = new BitacoraDAL();

        // TODO: Método normal (de instancia). Usa 1 foreach con 1 if interno para filtrar la lista.
        public List<Reserva> ObtenerReservasConfirmadas()
        {
            List<Reserva> confirmadas = new List<Reserva>();

            foreach (Reserva reserva in reservaDal.ObtenerTodas())
            {
                if (reserva.Estado == EstadosReserva.Confirmada)
                {
                    confirmadas.Add(reserva);
                }
            }

            return confirmadas;
        }

        // TODO: Método normal (de instancia). Sin estructuras de control, solo delega al DAL.
        public List<Estadia> ObtenerEstadiasActivas()
        {
            return estadiaDal.ObtenerTodasActivas();
        }

        // TODO: Método normal (de instancia). Usa 2 if (guard clauses) antes de crear la estadía.
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

        // TODO: Método normal (de instancia). Usa 2 if (guard clauses) + Math.Max (método estático de la clase Math, no propio).
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

            habitacionDal.ActualizarEstado(habitacionNumero, EstadosHabitacion.Limpieza);

            bitacoraDal.Registrar(usuarioId, "CheckOut",
                "Check-out de la habitacion " + habitacionNumero + ", factura " + ncf);
            bitacoraDal.Registrar(usuarioId, "Facturacion",
                "Factura " + ncf + " generada por RD$ " + total.ToString("N2"));

            return factura;
        }
    }
}