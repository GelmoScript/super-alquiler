using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAlquiler.Services
{
    public class CRUDFacturas
    {
        Conexion conexion = null;

        private void PatronSingleton()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            }
        }

        public void CreatePagarFactura (string opcion, int reserva_O_idfactura, double monto)
        {
            PatronSingleton();

            conexion.ConsultarFactura(opcion, reserva_O_idfactura, monto);
        }
    }
}
