using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAlquiler.Services
{
    public class CRUDReservas
    {
        Conexion conexion = null;

        List<string> _parametros = null;

        private void PatronSingleton()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            }
        }

        public void CreateReserva(int vehiculo, int cliente, DateTime fechaInicio, DateTime fechaFin, bool borrado)
        {
            PatronSingleton();

            _parametros = new List<string>() { "@VEHICULO", "@CLIENTE", "@FECHA_INICIO", "@FECHA_FIN", "@BORRADO" };

            conexion.ConsultarReserva(_parametros, vehiculo, cliente, fechaInicio, fechaFin, borrado);
        }

        public void DeleteReserva(int ID)
        {
            PatronSingleton();

            conexion.DeleteReserva(ID);
        }
    }
}
