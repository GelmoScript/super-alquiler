using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperAlquiler.Entities;

namespace SuperAlquiler.Services
{
    public class CRUDVehiculos
    {
        Conexion conexion = null;

        List<string> _parametros = null;
        List<string> _valores = null;

        private void PatronSingleton()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            }
        }

        public void Create (Vehiculo vehiculo)
        {
            PatronSingleton();

            conexion.ConsultarVehiculo("SP_INSERTAR_VEHICULO", vehiculo);
        }

        public List<Vehiculo> Read()
        {
            PatronSingleton();

            return conexion.SelectVehiculo();
        }

        public void Update (Vehiculo vehiculo)
        {
            PatronSingleton();
            
            conexion.ConsultarVehiculo("SP_MODIFICAR_VEHICULO", vehiculo);
        }

        public void Delete (int ID)
        {
            PatronSingleton();

            conexion.DeleteVehiculo(ID);
        }
    }
}
