using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SuperAlquiler.Entities;

namespace SuperAlquiler.Services
{
    public class CRUDClientes
    {
        Conexion conexion = null;

        private void PatronSingleton()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            }
        }

        public void Create (Cliente cliente)
        {
            PatronSingleton();
            
            conexion.ConsultarCliente("SP_INSERTAR_CLIENTES", cliente);
        }

        public Cliente Read()
        {
            PatronSingleton();

            return conexion.SelectCliente();
        }

        public void Update (Cliente cliente)
        {
            PatronSingleton();

            conexion.ConsultarCliente ("SP_MODIFICAR_CLIENTES", cliente);
        }

        public void Delete (int ID)
        {
            PatronSingleton();

            conexion.DeleteCliente(ID);
        }
    }
}
