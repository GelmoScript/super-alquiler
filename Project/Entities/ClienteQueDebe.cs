using System;
namespace SuperAlquiler.Entities
{
    public class ClienteQueDebe
    {
        public Cliente Cliente { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public double Monto { get; set; }
        public string NombreCompleto
        {
            get
            {
                return Nombre + " " + Apellido;
            }
        }
    }
}
