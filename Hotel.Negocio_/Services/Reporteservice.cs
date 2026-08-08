// Cedula: 402444623662
using Hotel.Negocio_.DaL;
using System;
using System.Collections.Generic;

namespace HotelZormat.Negocio.Servicios
{
    public class ReporteService
    {
        private ReporteDAL reporteDal = new ReporteDAL();
        private FacturaDAL facturaDal = new FacturaDAL();

        // TODO: Método normal (de instancia). Sin estructuras de control, solo delega al DAL.
        public List<Dictionary<string, object>> ObtenerOcupacionDelDia()
        {
            return reporteDal.ObtenerOcupacionDelDia();
        }

        // TODO: Método normal (de instancia). Usa 1 if (guard clause) antes de delegar al DAL.
        public decimal ObtenerIngresosPorRango(DateTime desde, DateTime hasta)
        {
            if (hasta < desde)
            {
                throw new FormatException("La fecha 'hasta' debe ser igual o posterior a la fecha 'desde'.");
            }

            return facturaDal.ObtenerIngresosPorRango(desde, hasta);
        }
    }
}