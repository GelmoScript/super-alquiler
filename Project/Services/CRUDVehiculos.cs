using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SuperAlquiler.Entities;

namespace SuperAlquiler.Services
{
    public class CRUDVehiculos
    {
        Conexion conexion = null;

        private void InstanciarConexion()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            }
        }

        public Vehiculo SelectByID(int id)
        {
            var vehiculos = Read();
            var vehiculo = vehiculos.FirstOrDefault(vehiculo => vehiculo.Id == id);

            return vehiculo;
        }

        public void Create (Vehiculo vehiculo)
        {
            InstanciarConexion();

            SqlConnection con = conexion.Conectar();

            SqlCommand cmd = new SqlCommand("SP_INSERTAR_VEHICULO", con);
            cmd.CommandType = CommandType.StoredProcedure;

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
            //cmd.Parameters.AddWithValue("@FOTO", vehiculo.Foto);
            cmd.Parameters.AddWithValue("@LATITUD", vehiculo.Latitud);
            cmd.Parameters.AddWithValue("@LONGITUD", vehiculo.Longitud);

            cmd.ExecuteNonQuery();

            conexion.Desconectar();
        }

      
        public List<Vehiculo> Read()
        {
            InstanciarConexion();

            SqlConnection con = conexion.Conectar();

            SqlCommand cmd = new SqlCommand("SELECT * FROM VEHICULOS WHERE BORRADO=0", con);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Vehiculo> lista = new List<Vehiculo>();

            while (reader.Read())
            {
                Vehiculo vehiculo = new Vehiculo();

                vehiculo.Id = reader.GetInt32("ID_VEHICULO");
                vehiculo.Marca = reader.GetString("MARCA");
                vehiculo.Modelo = reader.GetString("MODELO");
                vehiculo.Year = reader.GetInt32("YEARS");
                vehiculo.Color = reader.GetString("COLOR");
                vehiculo.PrecioPorDia = reader.GetDouble("PRECIO_POR_DIA");
                vehiculo.TipoVehiculo = reader.GetString("TIPO");
                vehiculo.CapacidadDeCarga = reader.GetInt32("CAPACIDAD_DE_CARGA");
                vehiculo.Pasajeros = reader.GetInt32("PASAJEROS");
                vehiculo.Matricula = reader.GetString("MATRICULA");
                vehiculo.NoSeguro = reader.GetString("NUMERO_DE_SEGURO");
                //vehiculo.Foto = (byte[])reader["FOTO"];
                vehiculo.Latitud = reader.GetDouble("LATITUD");
                vehiculo.Longitud = reader.GetDouble("LONGITUD");

                lista.Add(vehiculo);
            }

            return lista;
        }

        public void Update (Vehiculo vehiculo)
        {
            InstanciarConexion();

            SqlConnection con = conexion.Conectar();

            SqlCommand cmd = new SqlCommand("SP_MODIFICAR_VEHICULOS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_VEHICULO", vehiculo.Id);
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
            //cmd.Parameters.AddWithValue("@FOTO", vehiculo.Foto);
            cmd.Parameters.AddWithValue("@LATITUD", vehiculo.Latitud);
            cmd.Parameters.AddWithValue("@LONGITUD", vehiculo.Longitud);

            cmd.ExecuteNonQuery();

            conexion.Desconectar();
        }

        public void Delete (int id)
        {
            InstanciarConexion();

            SqlConnection con = conexion.Conectar();

            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_VEHICULOS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_VEHICULO", id);

            cmd.ExecuteNonQuery();
            conexion.Desconectar();
        }
    }
}
