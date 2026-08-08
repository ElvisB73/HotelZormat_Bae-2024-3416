// Cedula: 402444623662
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Negocio_
{
    public class HabitacionException : Exception
    {
        // TODO: Permite que quien atrape la excepción sepa exactamente
        // qué habitación causó el problema, sin tener que parsear
        // el texto del mensaje.
        public int NumeroHabitacion { get; }

        public HabitacionException(int Numero)
            : base($"La Habitacion {Numero} esta ocupada")
        {
            NumeroHabitacion = Numero;
        }
    }
}