using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAlquiler.Services
{
    public class CRUDClientes
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

        public void CreateUpdateCliente (string opcion, string cedula, string nombres, string apellidos, string correo, string licencia, string nacionalidad, string tipoSangre, Byte[] fotoCliente, Byte[] fotoCedula, bool estatus, bool borrado)
        {
            PatronSingleton();

            _parametros = new List<string>() { "@CEDULA", "@NOMBRES", "@APELLIDOS", "@CORREO", "@LICENCIA", "@TIPO_DE_SANGRE" };
            _valores = new List<string>() { cedula, nombres, apellidos, correo, licencia, tipoSangre };

            if (opcion.Equals("Insert"))
            {
                conexion.ConsultarCliente("SP_INSERTAR_CLIENTES", _parametros, _valores, fotoCliente, fotoCedula, estatus, borrado);
            }

            else 
            {
                conexion.ConsultarCliente("SP_MODIFICAR_CLIENTES", _parametros, _valores, fotoCliente, fotoCedula, estatus, borrado);
            }
        }

        public void DeleteCliente (int ID)
        {
            PatronSingleton();

            conexion.DeleteVehiculoClienteReserva("Cliente", ID);
        }
    }
}
