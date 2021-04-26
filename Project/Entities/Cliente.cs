using System;
namespace SuperAlquiler.Entities
{
    public class Cliente : EntidadBase, IClonador<Cliente>
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Licencia { get; set; }
        public string Nacionalidad { get; set; }
        public string TipoDeSangre { get; set; }
        public byte[] Foto { get; set; }
        public byte[] FotoLicencia { get; set; }
        public string NombreCompleto
        {
            get
            {
                return Nombre + " " + Apellido;
            }
        }

        public Cliente Clonar()
        {
            Cliente cliente = (Cliente) MemberwiseClone();
            return cliente;
        }

        public override string ToString()
        {
            return $"[{Cedula}] {NombreCompleto}";
        }


    }
}
