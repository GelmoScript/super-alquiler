using System;
namespace SuperAlquiler.Entities
{
    public class ReservaPorVehiculo
    {
        public Vehiculo Vehiculo { get; set; }
        public int Reservas { get; set; }
        public int DineroFacturado { get; set; }
    }
}
