// Cedula: 402444623662
using Hotel.Negocio_.DaL;
using Hotel.Negocio_.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelZormat.Negocio.Servicios
{
    /// <summary>
    /// Servicio de validaciones y operaciones de negocio para Huespedes.
    /// La UI llama a este servicio, nunca al HuespedDAL directamente.
    /// </summary>
    public class HuespedService
    {
        private HuespedDAL huespedDal = new HuespedDAL();

        // ── Valida que la cédula dominicana tenga exactamente 11 dígitos ──
        // Solo aplica cuando el tipo de documento es "Cedula". Si es
        // "Pasaporte", no se exige este formato porque los pasaportes
        // usan letras y números y varían de país a país.
        public bool ValidarCedula(string numeroDocumento)
        {
            if (string.IsNullOrWhiteSpace(numeroDocumento))
            {
                return false;
            }

            // Debe tener exactamente 11 caracteres y todos deben ser dígitos.
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

        // ── Valida los datos de un huésped antes de guardarlo ────────
        // Lanza FormatException con un mensaje claro si algo no es válido,
        // para que la UI lo atrape en su catch(FormatException) y muestre
        // el mensaje al usuario con MessageBox.
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

            if (huesped.TipoDocumento != TiposDocumento.Cedula && huesped.TipoDocumento != TiposDocumento.Pasaporte)
            {
                throw new FormatException("El tipo de documento debe ser Cedula o Pasaporte.");
            }

            if (huesped.TipoDocumento == TiposDocumento.Cedula && !ValidarCedula(huesped.NumeroDocumento))
            {
                throw new FormatException("La cédula debe tener exactamente 11 dígitos numéricos.");
            }

            if (huesped.TipoDocumento == TiposDocumento.Pasaporte && string.IsNullOrWhiteSpace(huesped.NumeroDocumento))
            {
                throw new FormatException("El número de pasaporte es obligatorio.");
            }
        }

        // ── Crea un huésped nuevo, validando antes de guardar ────────
        public void Crear(Huesped huesped)
        {
            ValidarHuesped(huesped);

            // No se permite un documento duplicado
            Huesped existente = huespedDal.BuscarPorDocumento(huesped.NumeroDocumento);
            if (existente != null)
            {
                throw new FormatException("Ya existe un huésped registrado con ese número de documento.");
            }

            huespedDal.Insertar(huesped);
        }

        // ── Actualiza un huésped existente, validando antes de guardar ──
        public void Actualizar(Huesped huesped)
        {
            ValidarHuesped(huesped);
            huespedDal.Actualizar(huesped);
        }

        // ── Elimina un huésped por Id ──────────────────────────────────
        public void Eliminar(int id)
        {
            huespedDal.Eliminar(id);
        }

        // ── Trae todos los huéspedes ────────────────────────────────
        public List<Huesped> ObtenerTodos()
        {
            return huespedDal.ObtenerTodos();
        }

        // ── Busca un huésped por su Id ───────────────────────────────
        public Huesped ObtenerPorId(int id)
        {
            return huespedDal.BuscarPorId(id);
        }

        // ── Busca por cédula/pasaporte exacto o por nombre parcial ───
        // Si el texto que escribió el usuario son puros dígitos y tiene
        // 11 caracteres, se asume que está buscando por cédula exacta.
        // En cualquier otro caso, se busca por nombre o apellido.
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

        // ── Historial de estadías de un huésped ──────────────────────
        public List<Dictionary<string, object>> ObtenerHistorial(int huespedId)
        {
            return huespedDal.ObtenerHistorialEstadias(huespedId);
        }
    }
}