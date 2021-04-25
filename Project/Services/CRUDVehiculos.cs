using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public void CreateVehiculo(string marca, string modelo, int year, string color, double precioDia, string tipo, int capacidadCarga, int pasajeros, string matricula, string numeroSeguro, Byte[] foto, string latitud, string longitud, bool estatus, bool borrado)
        {
            PatronSingleton();

            _parametros = new List<string>() { "@MARCA", "@MODELO", "@COLOR", "@TIPO", "@MATRICULA", "@NUMERO_DE_SEGURO", "@LATITUD", "@LONGITUD" };
            _valores = new List<string>() { marca, modelo, color, tipo, matricula, numeroSeguro, latitud, longitud };

            conexion.ConsultarVehiculo("SP_INSERTAR_VEHICULO", _parametros, _valores, year, precioDia, capacidadCarga, pasajeros, foto, estatus, borrado);
        }

        public void UpdateVehiculo(string opcion, string marca, string modelo, int year, string color, double precioDia, string tipo, int capacidadCarga, int pasajeros, string matricula, string numeroSeguro, Byte[] foto, string latitud, string longitud, bool estatus, bool borrado)
        {
            PatronSingleton();

            _parametros = new List<string>() { "@MARCA", "@MODELO", "@COLOR", "@TIPO", "@MATRICULA", "@NUMERO_DE_SEGURO", "@LATITUD", "@LONGITUD" };
            _valores = new List<string>() { marca, modelo, color, tipo, matricula, numeroSeguro, latitud, longitud };

            
            conexion.ConsultarVehiculo("SP_MODIFICAR_VEHICULO", _parametros, _valores, year, precioDia, capacidadCarga, pasajeros, foto, estatus, borrado);
        }

        public void DeleteVehiculo(int ID)
        {
            PatronSingleton();

            conexion.DeleteVehiculo(ID);
        }
    }
}
