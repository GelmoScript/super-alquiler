using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SuperAlquiler.Entities;

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

        public Vehiculo ConsultarVehiculo (string procedimiento)
        {
            Vehiculo vehiculo = new Vehiculo();

            Conectar();

            SqlCommand cmd = new SqlCommand(procedimiento, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            cmd.Parameters.AddWithValue("@MARCA", vehiculo.Marca);
            cmd.Parameters.AddWithValue("@MODELO", vehiculo.Modelo);
            cmd.Parameters.AddWithValue("@YEARS", vehiculo.Year);
            cmd.Parameters.AddWithValue("@COLOR", vehiculo.Color);
            cmd.Parameters.AddWithValue("@PRECIO_POR_DIA", vehiculo.PrecioPorDia);
            cmd.Parameters.AddWithValue("@TIPO", vehiculo.TipoVehiculo);
            cmd.Parameters.AddWithValue("@CAPACIDAD_DE_CARGA", vehiculo.CapacidadDeCarga);
            cmd.Parameters.AddWithValue("@PASAJEROS", vehiculo.Pasajeros);
            cmd.Parameters.AddWithValue("@MATRICULA", vehiculo.Matricula);
            cmd.Parameters.AddWithValue("@NUMERO_DE_SEGURO", vehiculo.NoSeguro);
            cmd.Parameters.AddWithValue("@FOTO", vehiculo.Foto);
            cmd.Parameters.AddWithValue("@LATITUD", vehiculo.Latitud);
            cmd.Parameters.AddWithValue("@LONGITUD", vehiculo.Longitud);

            con.Close();

            return vehiculo;
        }

        public List<Vehiculo> SelectVehiculo ()
        {
            Vehiculo vehiculo = new Vehiculo();

            Conectar();
            
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM VEHICULOS", con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                vehiculo.Id = reader.GetInt32("ID_VEHICULO");
                vehiculo.Marca = reader.GetString("MARCA");
                vehiculo.Modelo = reader.GetString("MODELO");
                vehiculo.Year = reader.GetInt32("YEARS");
                vehiculo.Color = reader.GetString("COLOR");
                vehiculo.PrecioPorDia = reader.GetDecimal("PRECIO_POR_DIA");
                vehiculo.TipoVehiculo.Nombre = reader.GetString("TIPO");
                vehiculo.CapacidadDeCarga = reader.GetInt32("CAPACIDAD_DE_CARGA");
                vehiculo.Pasajeros = reader.GetInt32("PASAJEROS");
                vehiculo.Matricula = reader.GetString("MATRICULA");
                vehiculo.NoSeguro = reader.GetString("NUMERO_DE_SEGURO");
                vehiculo.Foto = (byte[]) reader["FOTO"];
                vehiculo.Latitud = Convert.ToDecimal(reader.GetString("LATITUD"));
                vehiculo.Longitud = Convert.ToDecimal(reader.GetString("LONGITUD"));
            }

            List<Vehiculo> lista = new() { vehiculo };

            return lista;
        }

        public Cliente ConsultarCliente (string procedimiento)
        {
            Cliente cliente = new Cliente();

            Conectar();

            SqlCommand cmd = new SqlCommand(procedimiento, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            cmd.Parameters.AddWithValue("@CEDULA", cliente.Cedula);
            cmd.Parameters.AddWithValue("@NOMBRES", cliente.Nombre);
            cmd.Parameters.AddWithValue("@APELLIDOS", cliente.Apellido);
            cmd.Parameters.AddWithValue("@CORREO", cliente.Correo);
            cmd.Parameters.AddWithValue("@LICENCIA", cliente.Licencia);
            cmd.Parameters.AddWithValue("@NACIONALIDAD", cliente.Nacionalidad);
            cmd.Parameters.AddWithValue("@TIPO_DE_SANGRE", cliente.TipoDeSangre);
            cmd.Parameters.AddWithValue("@FOTO_CLIENTE", cliente.FotoLicencia);
            cmd.Parameters.AddWithValue("@FOTO_CEDULA", cliente.Foto);

            con.Close();

            return cliente;
        }

        public List<Cliente> SelectCliente()
        {
            Cliente cliente = new Cliente();

            Conectar();

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM CLIENTES", con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                cliente.Cedula = reader.GetString("CEDULA");
                cliente.Nombre = reader.GetString("NOMBRES");
                cliente.Apellido = reader.GetString("APELLIDOS");
                cliente.Correo = reader.GetString("CORREO");
                cliente.Licencia = reader.GetString("LICENCIA");
                cliente.Nacionalidad = reader.GetString("NACIONALIDAD");
                cliente.TipoDeSangre = reader.GetString("TIPO_DE_SANGRE");
                cliente.FotoLicencia = (byte[])reader["FOTO_CLIENTE"];
                cliente.Foto = (byte[])reader["FOTO_CEDULA"];
            }

            List<Cliente> lista = new() { cliente };

            return lista;
        }

        public Reserva ConsultarReserva ()
        {
            Reserva reserva = new Reserva();

            Conectar();

            SqlCommand cmd = new SqlCommand("SP_INSERTAR_RESERVA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            cmd.Parameters.AddWithValue("@VEHICULO", reserva.Vehiculo.Id);
            cmd.Parameters.AddWithValue("@CLIENTE", reserva.Cliente.Id);
            cmd.Parameters.AddWithValue("@FECHA_INICIO", reserva.FechaInicio);
            cmd.Parameters.AddWithValue("@FECHA_FIN", reserva.FechaFin);

            con.Close();

            return reserva;
        }

        public List<Reserva> SelectReserva()
        {
            Reserva reserva = new Reserva();

            Conectar();

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM RESERVAS", con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                reserva.Vehiculo = (Vehiculo) reader["VEHICULO"];
                reserva.Cliente = (Cliente) reader["CLIENTE"];
                reserva.FechaInicio = reader.GetDateTime("FECHA_INICIO");
                reserva.FechaFin = reader.GetDateTime("FECHA_FIN");
            }

            List<Reserva> lista = new() { reserva };

            return lista;
        }

        public void CrearFactura (int reserva, double monto)
        {
            Conectar();

            SqlCommand cmd = new SqlCommand("SP_INSERTAR_FACTURA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            cmd.Parameters.AddWithValue("@RESERVA", reserva);
            cmd.Parameters.AddWithValue("@MONTO_A_PAGAR", monto);

            con.Close();
        }

        public void PagarFactura(int FacturaID, double monto)
        {
            Conectar();

            SqlCommand cmd = new SqlCommand("SP_PAGAR_FACTURA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            cmd.Parameters.AddWithValue("@ID_FACTURA", FacturaID);
            cmd.Parameters.AddWithValue("@MONTO_A_PAGAR", monto);

            con.Close();
        }

        public void DeleteVehiculo(int ID)
        {
            Conectar();

            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_VEHICULOS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            cmd.Parameters.AddWithValue("@ID_VEHICULO", ID);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteCliente(int ID)
        {
            Conectar();

            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_CLIENTES", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            cmd.Parameters.AddWithValue("@ID_CLIENTE", ID);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteReserva(int ID)
        {
            Conectar();

            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_RESERVA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            cmd.Parameters.AddWithValue("@ID_RESERVAS", ID);

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
