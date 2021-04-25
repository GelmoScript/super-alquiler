using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAlquiler.Services
{


    public class Conexion
    {
        private SqlConnection con = null;

        public void Conectar()
        {
            if (con == null)
            {
                con = new SqlConnection("Server=tcp:gelmo-server.database.windows.net,1433;Initial Catalog=GelmoDatabase;Persist Security Info=False;User ID=gelmoadmin;Password=GelmoPassword71;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        public void ConsultarVehiculo(string procedimiento, List<string> parametros, List<string> valores, int year, double precioDia, int capacidadCarga, int pasajeros, Byte[] foto, bool estatus, bool borrado)
        {
            Conectar();

            SqlCommand cmd = new SqlCommand(procedimiento, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            for (int i = 0; i < parametros.Count; i++)
            {
                cmd.Parameters.AddWithValue(parametros.ElementAt(i), valores.ElementAt(i));
            }

            cmd.Parameters.AddWithValue("@AÑO", year);
            cmd.Parameters.AddWithValue("@PRECIO_POR_DIA", precioDia);
            cmd.Parameters.AddWithValue("@CAPACIDAD_DE_CARGA", capacidadCarga);
            cmd.Parameters.AddWithValue("@PASAJEROS", pasajeros);
            cmd.Parameters.AddWithValue("@FOTO", foto);
            cmd.Parameters.AddWithValue("@ESTATUS", estatus);
            cmd.Parameters.AddWithValue("@BORRADO", borrado);

            con.Close();
        }

        public void ConsultarCliente (string procedimiento, List<string> parametros, List<string> valores, Byte[] fotoCliente, Byte[] fotoCedula, bool estatus, bool borrado)
        {
            Conectar();

            SqlCommand cmd = new SqlCommand(procedimiento, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            for (int i = 0; i < parametros.Count; i++)
            {
                cmd.Parameters.AddWithValue(parametros.ElementAt(i), valores.ElementAt(i));
            }

            cmd.Parameters.AddWithValue("@FOTO_CLIENTE", fotoCliente);
            cmd.Parameters.AddWithValue("@FOTO_CEDULA", fotoCedula);
            cmd.Parameters.AddWithValue("@ESTATUS", estatus);
            cmd.Parameters.AddWithValue("@BORRADO", borrado);

            con.Close();
        }

        public void ConsultarReserva(List<string> parametros, int vehiculo, int cliente, DateTime fechaInicio, DateTime fechaFin, bool borrado)
        {
            Conectar();

            SqlCommand cmd = new SqlCommand("SP_INSERTAR_RESERVA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            cmd.Parameters.AddWithValue("@VEHICULO", vehiculo);
            cmd.Parameters.AddWithValue("@CLIENTE", cliente);
            cmd.Parameters.AddWithValue("@FECHA_INICIO", fechaInicio);
            cmd.Parameters.AddWithValue("@FECHA_FIN", fechaFin);
            cmd.Parameters.AddWithValue("@BORRADO", borrado);

            con.Close();
        }

        public void ConsultarFactura (string opcion, int reserva_O_idfactura, double monto)
        {
            Conectar();

            string procedimiento, campo;

            if (opcion.Equals("Insert"))
            {
                procedimiento = "SP_INSERTAR_FACTURA";
                campo = "@RESERVA";
            }

            else
            {
                procedimiento = "SP_PAGAR_FACTURA";
                campo = "@ID_FACTURA";
            }

            SqlCommand cmd = new SqlCommand(procedimiento, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            cmd.Parameters.AddWithValue(campo, reserva_O_idfactura);
            cmd.Parameters.AddWithValue("@MONTO_A_PAGAR", monto);

            con.Close();
        }

        public void DeleteVehiculoClienteReserva(string opcion, int ID)
        {
            Conectar();

            string procedimiento, campoID;

            if (opcion.Equals("Cliente"))
            {
                procedimiento = "SP_ELIMINAR_CLIENTES";
                campoID = "@ID_CLIENTE";
            }

            else if (opcion.Equals("Vehiculo"))
            {
                procedimiento = "SP_ELIMINAR_VEHICULOS";
                campoID = "@ID_VEHICULO";
            }

            else
            {
                procedimiento = "SP_ELIMINAR_RESERVA";
                campoID = "@ID_RESERVAS";
            }

            SqlCommand cmd = new SqlCommand(procedimiento, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            cmd.Parameters.AddWithValue(campoID, ID);

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
