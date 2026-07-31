using Hotel.Negocio_;
using Hotel.Negocio_.DaL;
using Hotel.Negocio_.Modelo;
using System;
using System.Collections.Generic;

namespace HotelZormat.Negocio.Servicios
{
    /// <summary>
    /// Servicio de validaciones y operaciones de negocio para Habitaciones.
    /// La UI llama a este servicio, nunca al HabitacionDAL directamente.
    /// </summary>
    public class HabitacionService
    {
        private HabitacionDAL habitacionDal = new HabitacionDAL();

        // ── Valida los datos de una habitación antes de guardarla ────
        public void ValidarHabitacion(Habitacion habitacion)
        {
            if (habitacion == null)
            {
                throw new ArgumentNullException(nameof(habitacion));
            }

            if (habitacion.Numero <= 0)
            {
                throw new FormatException("El número de habitación debe ser mayor a cero.");
            }

            if (habitacion.Piso <= 0)
            {
                throw new FormatException("El piso debe ser mayor a cero.");
            }

            if (habitacion.Capacidad <= 0)
            {
                throw new FormatException("La capacidad debe ser mayor a cero.");
            }

            if (habitacion.Tarifa <= 0)
            {
                throw new FormatException("La tarifa debe ser mayor a cero.");
            }

            if (habitacion.Tipo != "Sencilla" && habitacion.Tipo != "Doble" && habitacion.Tipo != "Suite")
            {
                throw new FormatException("El tipo debe ser Sencilla, Doble o Suite.");
            }

            bool estadoValido = habitacion.Estado == EstadosHabitacion.Disponible
                || habitacion.Estado == EstadosHabitacion.Ocupada
                || habitacion.Estado == EstadosHabitacion.Reservada
                || habitacion.Estado == EstadosHabitacion.Limpieza;

            if (!estadoValido)
            {
                throw new FormatException("El estado de la habitación no es válido.");
            }
        }

        // ── Crea una habitación nueva, validando antes de guardar ────
        public void Crear(Habitacion habitacion)
        {
            ValidarHabitacion(habitacion);

            Habitacion existente = habitacionDal.BuscarPorNumero(habitacion.Numero);
            if (existente != null)
            {
                throw new FormatException("Ya existe una habitación con ese número.");
            }

            habitacionDal.Insertar(habitacion);
        }

        // ── Actualiza tipo, capacidad, tarifa y estado ────────────────
        public void Actualizar(Habitacion habitacion)
        {
            ValidarHabitacion(habitacion);
            habitacionDal.ActualizarCompleto(habitacion);
        }

        // ── Elimina una habitación. Solo debería llamarse desde la UI ──
        // cuando el rol es Administrador (esa validación de rol va en
        // el formulario, aquí solo se valida que no esté ocupada).
        public void Eliminar(int numero)
        {
            Habitacion habitacion = habitacionDal.BuscarPorNumero(numero);

            if (habitacion == null)
            {
                throw new FormatException("La habitación no existe.");
            }

            if (habitacion.Estado == EstadosHabitacion.Ocupada)
            {
                throw new HabitacionException(numero);
            }

            habitacionDal.Eliminar(numero);
        }

        // ── Cambia solo el estado, validando que sea uno de los 4 válidos ──
        public void CambiarEstado(int numero, string nuevoEstado)
        {
            bool estadoValido = nuevoEstado == EstadosHabitacion.Disponible
                || nuevoEstado == EstadosHabitacion.Ocupada
                || nuevoEstado == EstadosHabitacion.Reservada
                || nuevoEstado == EstadosHabitacion.Limpieza;

            if (!estadoValido)
            {
                throw new FormatException("El estado indicado no es válido.");
            }

            habitacionDal.ActualizarEstado(numero, nuevoEstado);
        }

        // ── Consultas, delegadas directo al repositorio ───────────────
        public List<Habitacion> ObtenerTodas()
        {
            return habitacionDal.ObtenerTodas();
        }

        public List<Habitacion> ObtenerConFiltros(int? piso, string estado)
        {
            return habitacionDal.ObtenerConFiltros(piso, estado);
        }

        public Habitacion BuscarPorNumero(int numero)
        {
            return habitacionDal.BuscarPorNumero(numero);
        }
    }
}