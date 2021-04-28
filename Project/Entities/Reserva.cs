using System;
namespace SuperAlquiler.Entities
{
    public class Reserva : EntidadBase, IClonador<Reserva>
    {
        public Reserva()
        {
            Vehiculo = new Vehiculo();
            Cliente = new Cliente();
        }
        //public int id { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        public Reserva Clonar()
        {
            Reserva reserva = (Reserva)MemberwiseClone();
            reserva.Cliente = Cliente.Clonar();
            reserva.Vehiculo = Vehiculo.Clonar();
            return reserva;
        }
    }
}
