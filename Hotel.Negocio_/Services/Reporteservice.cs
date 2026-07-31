// Cedula: 402444623662
using Hotel.Negocio_.DaL;
using System;
using System.Collections.Generic;

namespace HotelZormat.Negocio.Servicios
{
    /// <summary>
    /// Servicio de reportes. La UI llama a este servicio, nunca a
    /// ReporteDAL o FacturaDAL directamente.
    /// </summary>
    public class ReporteService
    {
        private ReporteDAL reporteDal = new ReporteDAL();
        private FacturaDAL facturaDal = new FacturaDAL();

        // ── Reporte 1: Ocupación del día ──────────────────────────────
        public List<Dictionary<string, object>> ObtenerOcupacionDelDia()
        {
            return reporteDal.ObtenerOcupacionDelDia();
        }

        // ── Reporte 2: Ingresos por rango de fecha ────────────────────
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