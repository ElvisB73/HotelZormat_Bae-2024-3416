// Cedula: 402444623662
using Hotel.Negocio_;
using Hotel.Negocio_.DaL;
using Hotel.Negocio_.Modelo;
using System;
using System.Collections.Generic;

namespace HotelZormat.Negocio.Servicios
{
    public class HabitacionService
    {
        private HabitacionDAL habitacionDal = new HabitacionDAL();

        // TODO: Método normal (de instancia). Usa 4 if independientes (Numero/Piso/Capacidad/Tarifa,
        // no se pueden unir en switch porque cada uno valida una variable distinta) + 2 switch (Tipo y Estado).
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

            switch (habitacion.Tipo)
            {
                case TiposHabitacion.Sencilla:
                case TiposHabitacion.Doble:
                case TiposHabitacion.Suite:
                    break; // tipo válido, no hace falta hacer nada

                default:
                    throw new FormatException("El tipo debe ser Sencilla, Doble o Suite.");
            }

            switch (habitacion.Estado)
            {
                case EstadosHabitacion.Disponible:
                case EstadosHabitacion.Ocupada:
                case EstadosHabitacion.Reservada:
                case EstadosHabitacion.Limpieza:
                    break; // estado válido, no hace falta hacer nada

                default:
                    throw new FormatException("El estado de la habitación no es válido.");
            }
        }

        // TODO: Método normal (de instancia). Usa 1 if (guard clause) antes de guardar.
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

        // TODO: Método normal (de instancia). Sin estructuras de control propias, delega a ValidarHabitacion y al DAL.
        public void Actualizar(Habitacion habitacion)
        {
            ValidarHabitacion(habitacion);
            habitacionDal.ActualizarCompleto(habitacion);
        }

        // TODO: Método normal (de instancia). Usa 2 if (guard clauses).
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

        // TODO: Método normal (de instancia). Usa 1 switch (con 4 casos que caen en el mismo break) + 1 if.
        public void CambiarEstado(int numero, string nuevoEstado)
        {
            switch (nuevoEstado)
            {
                case EstadosHabitacion.Disponible:
                case EstadosHabitacion.Ocupada:
                case EstadosHabitacion.Reservada:
                case EstadosHabitacion.Limpieza:
                    break; // estado válido, no hace falta hacer nada

                default:
                    throw new FormatException("El estado indicado no es válido.");
            }

            habitacionDal.ActualizarEstado(numero, nuevoEstado);
        }

        // TODO: Método normal (de instancia). Sin estructuras de control, solo delega al DAL.
        public List<Habitacion> ObtenerTodas()
        {
            return habitacionDal.ObtenerTodas();
        }

        // TODO: Método normal (de instancia). Sin estructuras de control, solo delega al DAL.
        public List<Habitacion> ObtenerConFiltros(int? piso, string estado)
        {
            return habitacionDal.ObtenerConFiltros(piso, estado);
        }

        // TODO: Método normal (de instancia). Sin estructuras de control, solo delega al DAL.
        public Habitacion BuscarPorNumero(int numero)
        {
            return habitacionDal.BuscarPorNumero(numero);
        }
    }
}