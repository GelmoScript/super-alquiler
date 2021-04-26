using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SuperAlquiler.Entities;

namespace SuperAlquiler.Services
{
    public class CRUDFacturas
    {
        Conexion conexion = null;

        private void InstanciarConexion()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            }
        }

        public Factura SelectByID (int id)
        {
            var facturas = Read();
            var factura = facturas.FirstOrDefault(factura => factura.Id == id);

            return factura;
        }

        public void Create (int reserva, double monto)
        {
            InstanciarConexion();

            SqlConnection con = conexion.Conectar();

            SqlCommand cmd = new SqlCommand("SP_INSERTAR_FACTURA", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RESERVA", reserva);
            cmd.Parameters.AddWithValue("@MONTO_A_PAGAR", monto);

            cmd.ExecuteNonQuery();

            conexion.Desconectar();
        }

        public List<Factura> Read()
        {
            InstanciarConexion();

            SqlConnection con = conexion.Conectar();

            SqlCommand cmd = new SqlCommand("SELECT * FROM FACTURAS", con);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Factura> lista = new List<Factura>();

            while (reader.Read())
            {
                Factura factura = new Factura();

                factura.Reserva.Id = reader.GetInt32("RESERVA");
                factura.MontoAPagar = reader.GetDouble("MONTO_A_PAGAR");
                factura.PendienteDePago = reader.GetDouble("PENDIENTE_DE_PAGO");

                lista.Add(factura);
            }

            return lista;
        }

        public void Pagar (int FacturaID, double monto)
        {
            InstanciarConexion();

            SqlConnection con = conexion.Conectar();

            SqlCommand cmd = new SqlCommand("SP_PAGAR_FACTURA", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_FACTURA", FacturaID);
            cmd.Parameters.AddWithValue("@MONTO_A_PAGAR", monto);

            cmd.ExecuteNonQuery();

            conexion.Desconectar();
        }
    }
}
