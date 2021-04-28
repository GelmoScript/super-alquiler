using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SuperAlquiler.Entities;
using System.IO;

namespace SuperAlquiler.Services
{
    public class CRUDClientes
    {
        string ruta;
        Conexion conexion = null;

        private void InstanciarConexion()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            }
        }

        public Cliente SelectByID (int id)
        {
            var clientes = Read();
            var cliente = clientes.FirstOrDefault(cliente => cliente.Id == id);

            return cliente;
        }

        public void Create (Cliente cliente)
        {
            InstanciarConexion();
            
            //FileStream stream = new FileStream(ruta, FileMode.Open, FileAccess.Read);
            //BinaryReader br = new BinaryReader(stream);
            //FileInfo fi = new FileInfo(ruta);


            //byte[] binData = new byte[stream.Length];

            //stream.Read(binData, 0, Convert.ToInt32(stream.Length));

            //cliente.Foto = Image.FromStream(stream);

            SqlConnection con = conexion.Conectar();

            SqlCommand cmd = new SqlCommand("SP_INSERTAR_CLIENTES", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CEDULA", cliente.Cedula);
            cmd.Parameters.AddWithValue("@NOMBRES", cliente.Nombre);
            cmd.Parameters.AddWithValue("@APELLIDOS", cliente.Apellido);
            cmd.Parameters.AddWithValue("@CORREO", cliente.Correo);
            cmd.Parameters.AddWithValue("@LICENCIA", cliente.Licencia);
            cmd.Parameters.AddWithValue("@NACIONALIDAD", cliente.Nacionalidad);
            cmd.Parameters.AddWithValue("@TIPO_DE_SANGRE", cliente.TipoDeSangre);
            //cmd.Parameters.AddWithValue("@FOTO_CLIENTE", cliente.Foto);
            //cmd.Parameters.AddWithValue("@FOTO_CEDULA", cliente.FotoLicencia);
            cmd.ExecuteNonQuery();

            conexion.Desconectar();
        }

        public List<Cliente> Read()
        {
            InstanciarConexion();

            SqlConnection con = conexion.Conectar();

            SqlCommand cmd = new SqlCommand("SELECT *FROM CLIENTES WHERE BORRADO=0", con);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Cliente> lista = new List<Cliente>();

            while (reader.Read())
            {
                
                Cliente cliente = new Cliente();
                cliente.Id = reader.GetInt32("ID_CLIENTE");
                cliente.Cedula = reader.GetString("CEDULA");
                cliente.Nombre = reader.GetString("NOMBRES");
                cliente.Apellido = reader.GetString("APELLIDOS");
                cliente.Correo = reader.GetString("CORREO");
                cliente.Licencia = reader.GetString("LICENCIA");
                cliente.Nacionalidad = reader.GetString("NACIONALIDAD");
                cliente.TipoDeSangre = reader.GetString("TIPO_DE_SANGRE");
                //cliente.FotoLicencia = (Byte[])reader["FOTO_CEDULA"];
                //cliente.Foto = (Byte[])reader["FOTO_CLIENTE"];

                lista.Add(cliente);
            }

            return lista;
        }

        public void Update (Cliente cliente)
        {
            InstanciarConexion();

            SqlConnection con = conexion.Conectar();

            SqlCommand cmd = new SqlCommand("SP_MODIFICAR_CLIENTES", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_CLIENTE", cliente.Id);
            cmd.Parameters.AddWithValue("@CEDULA", cliente.Cedula);
            cmd.Parameters.AddWithValue("@NOMBRES", cliente.Nombre);
            cmd.Parameters.AddWithValue("@APELLIDOS", cliente.Apellido);
            cmd.Parameters.AddWithValue("@CORREO", cliente.Correo);
            cmd.Parameters.AddWithValue("@LICENCIA", cliente.Licencia);
            cmd.Parameters.AddWithValue("@NACIONALIDAD", cliente.Nacionalidad);
            cmd.Parameters.AddWithValue("@TIPO_DE_SANGRE", cliente.TipoDeSangre);
            //cmd.Parameters.AddWithValue("@FOTO_CLIENTE", cliente.Foto);
            //cmd.Parameters.AddWithValue("@FOTO_CEDULA", cliente.FotoLicencia);

            cmd.ExecuteNonQuery();

            conexion.Desconectar();
        }

        public void Delete (int id)
        {
            InstanciarConexion();

            SqlConnection con = conexion.Conectar();

            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_CLIENTE", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_CLIENTE", id);

            cmd.ExecuteNonQuery();
            conexion.Desconectar();
        }
    }
}
