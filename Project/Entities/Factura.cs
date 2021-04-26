using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAlquiler.Entities
{
    public class Factura : EntidadBase
    {
        public Factura()
        {
            Reserva = new Reserva();
        }

        public Reserva Reserva { get; set; }
        public double MontoAPagar { get; set; }
        public double PendienteDePago { get; set; }

    }
}
