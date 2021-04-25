﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAlquiler.Services
{
    public class CRUDFacturas
    {
        Conexion conexion = null;

        private void PatronSingleton()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            }
        }

        public void CreateFactura (int reserva, double monto)
        {
            PatronSingleton();

            conexion.CrearFactura(reserva, monto);
        }

        public void PagarFactura(int FacturaID, double monto)
        {
            PatronSingleton();

            conexion.PagarFactura(FacturaID, monto);
        }
    }
}
