using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperAlquiler.Entities;

namespace SuperAlquiler.Services
{
    public class CRUDReservas
    {
        Conexion conexion = null;

        private void PatronSingleton()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            }
        }

        public void Create (Reserva reserva)
        {
            PatronSingleton();

            conexion.ConsultarReserva (reserva);
        }

        public List<Reserva> Read()
        {
            PatronSingleton();

            return conexion.SelectReserva();
        }

        public void Delete (int ID)
        {
            PatronSingleton();

            conexion.DeleteReserva(ID);
        }
    }
}
