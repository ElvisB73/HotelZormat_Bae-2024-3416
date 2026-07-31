using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hotel.Datos
{
    public static class configuracionDB
    {
        public static string ObtenerConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["HotelBae"].ConnectionString;
        }

        public  static SqlConnection obtenerconexion()
        {
            return new SqlConnection(ObtenerConnectionString());
        }
    }
}
