// Cedula: 402-4462366-2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelZormat
{
    internal static class Program
    {
        // Matricula del estudiante, requerida por la practica ISW-123
        // como marcador anti-IA (Elvis Baez, matricula 2024-3416).
        static string matricula = "2024-3416";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}