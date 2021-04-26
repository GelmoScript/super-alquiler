using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SuperAlquiler.Entities;

namespace SuperAlquiler.Services
{
    public class CRUDReservas
    {
        Conexion conexion = null;

        private void InstanciarConexion()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            }
        }

        public Reserva SelectByID(int id)
        {
            var reservas = Read();
            var reserva = reservas.FirstOrDefault(reserva => reserva.Id == id);

            return reserva;
        }

        public void Create (Reserva reserva)
        {
            InstanciarConexion();

            SqlConnection con = conexion.Conectar();

            SqlCommand cmd = new SqlCommand("SP_INSERTAR_RESERVA", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@VEHICULO", reserva.Vehiculo.Id);
            cmd.Parameters.AddWithValue("@CLIENTE", reserva.Cliente.Id);
            cmd.Parameters.AddWithValue("@FECHA_INICIO", reserva.FechaInicio);
            cmd.Parameters.AddWithValue("@FECHA_FIN", reserva.FechaFin);

            cmd.ExecuteNonQuery();

            conexion.Desconectar();
        }

        public List<Reserva> Read()
        {
            InstanciarConexion();

            SqlConnection con = conexion.Conectar();

            SqlCommand cmd = new SqlCommand("SELECT * FROM RESERVAS", con);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Reserva> lista = new List<Reserva>();

            while (reader.Read())
            {
                Reserva reserva = new Reserva();

                reserva.Vehiculo.Id = reader.GetInt32("VEHICULO");
                reserva.Cliente.Id = reader.GetInt32("CLIENTE");
                reserva.FechaInicio = reader.GetDateTime("FECHA_INICIO");
                reserva.FechaFin = reader.GetDateTime("FECHA_FIN");

                lista.Add(reserva);
            }

            return lista;
        }

        public void Delete (int id)
        {
            InstanciarConexion();

            SqlConnection con = conexion.Conectar();

            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_RESERVA", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_RESERVAS", id);

            cmd.ExecuteNonQuery();
            conexion.Desconectar();
        }
    }
}
