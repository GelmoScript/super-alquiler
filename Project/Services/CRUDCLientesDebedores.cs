using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperAlquiler.Entities;
using System.Data;
using System.Data.SqlClient;

namespace SuperAlquiler.Services
{
    public class CRUDCLientesDebedores
    {
        Conexion conexion = null;

        private void InstanciarConexion()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            }
        }

        public List<ClienteQueDebe> Read() 
        {
            InstanciarConexion();

            SqlConnection con = conexion.Conectar();

            SqlCommand cmd = new SqlCommand("SELECT CLIENTES.CEDULA, CLIENTES.NOMBRES, CLIENTES.APELLIDOS, FACTURAS.PENDIENTE_DE_PAGO FROM FACTURAS JOIN RESERVAS ON FACTURAS.RESERVA =RESERVAS.ID_RESERVAS JOIN CLIENTES ON RESERVAS.CLIENTE = CLIENTES.ID_CLIENTE", con);
            SqlDataReader reader = cmd.ExecuteReader();

            List<ClienteQueDebe> lista = new List<ClienteQueDebe>();

            while (reader.Read())
            {
                ClienteQueDebe clientequedebe = new ClienteQueDebe();
                clientequedebe.Cliente.Cedula = reader.GetString("CEDULA");
                clientequedebe.Cliente.Nombre = reader.GetString("NOMBRES");
                clientequedebe.Monto = reader.GetInt32("PENDIENTE_DE_PAGO");
                lista.Add(clientequedebe);
            }

            return lista;
        }
    }
}
