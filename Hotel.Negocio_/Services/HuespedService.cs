// Cedula: 402444623662
using Hotel.Negocio_.DaL;
using Hotel.Negocio_.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelZormat.Negocio.Servicios
{
    public class HuespedService
    {
        private HuespedDAL huespedDal = new HuespedDAL();

        // TODO: Método normal (de instancia). Usa 2 if (guard clauses) + 1 foreach con if interno.
        public bool ValidarCedula(string numeroDocumento)
        {
            if (string.IsNullOrWhiteSpace(numeroDocumento))
            {
                return false;
            }

            if (numeroDocumento.Length != 11)
            {
                return false;
            }

            foreach (char c in numeroDocumento)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        // TODO: Método normal (de instancia). Usa 3 if (guard clauses) + 1 switch con 3 casos.
        public void ValidarHuesped(Huesped huesped)
        {
            if (huesped == null)
            {
                throw new ArgumentNullException(nameof(huesped));
            }

            if (string.IsNullOrWhiteSpace(huesped.Nombre))
            {
                throw new FormatException("El nombre del huésped es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(huesped.Apellido))
            {
                throw new FormatException("El apellido del huésped es obligatorio.");
            }

            switch (huesped.TipoDocumento)
            {
                case TiposDocumento.Cedula:
                    if (!ValidarCedula(huesped.NumeroDocumento))
                    {
                        throw new FormatException("La cédula debe tener exactamente 11 dígitos.");
                    }
                    break;

                case TiposDocumento.Pasaporte:
                    if (string.IsNullOrWhiteSpace(huesped.NumeroDocumento))
                    {
                        throw new FormatException("El número de pasaporte es obligatorio.");
                    }
                    break;

                default:
                    throw new FormatException("El tipo de documento no es válido.");
            }
        }

        // TODO: Método normal (de instancia). Usa 1 if (guard clause) antes de guardar.
        public void Crear(Huesped huesped)
        {
            ValidarHuesped(huesped);

            Huesped existente = huespedDal.BuscarPorDocumento(huesped.NumeroDocumento);
            if (existente != null)
            {
                throw new FormatException("Ya existe un huésped registrado con ese número de documento.");
            }

            huespedDal.Insertar(huesped);
        }

        // TODO: Método normal (de instancia). Sin estructuras de control propias, delega a ValidarHuesped y al DAL.
        public void Actualizar(Huesped huesped)
        {
            ValidarHuesped(huesped);
            huespedDal.Actualizar(huesped);
        }

        // TODO: Método normal (de instancia). Sin estructuras de control, solo delega al DAL.
        public void Eliminar(int id)
        {
            huespedDal.Eliminar(id);
        }

        // TODO: Método normal (de instancia). Sin estructuras de control, solo delega al DAL.
        public List<Huesped> ObtenerTodos()
        {
            return huespedDal.ObtenerTodos();
        }

        // TODO: Método normal (de instancia). Sin estructuras de control, solo delega al DAL.
        public Huesped ObtenerPorId(int id)
        {
            return huespedDal.BuscarPorId(id);
        }

        // TODO: Método normal (de instancia). Usa 2 if + 1 operador ternario (condición ? valorSiVerdadero : valorSiFalso).
        public List<Huesped> Buscar(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return ObtenerTodos();
            }

            if (ValidarCedula(texto))
            {
                Huesped encontrado = huespedDal.BuscarPorDocumento(texto);
                return encontrado != null
                    ? new List<Huesped> { encontrado }
                    : new List<Huesped>();
            }

            return huespedDal.BuscarPorNombre(texto);
        }

        // TODO: Método normal (de instancia). Sin estructuras de control, solo delega al DAL.
        public List<Dictionary<string, object>> ObtenerHistorial(int huespedId)
        {
            return huespedDal.ObtenerHistorialEstadias(huespedId);
        }
    }
}