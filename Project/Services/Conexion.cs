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
        
        public SqlConnection Conectar()
        {
            if (con == null)
            {
                con = new SqlConnection("Server=tcp:gelmo-server.database.windows.net,1433;Initial Catalog=GelmoDatabase;Persist Security Info=False;User ID=gelmoadmin;Password=GelmoPassword71;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                con.Open();
                return con;
            }

            else 
            {
                return con;
            }
        }

        public void Desconectar()
        {
            con.Close();
        }
    }
}
