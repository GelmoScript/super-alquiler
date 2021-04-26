using System;
using System.Collections.Generic;
using SuperAlquiler.Entities;

namespace SuperAlquiler.Seed
{
    public class DatosSemilla
    {
        private readonly static DatosSemilla _instancia = new DatosSemilla();
        public static DatosSemilla Instancia {
            get{
                return _instancia;
            }
        }
        private DatosSemilla()
        {
        }

        public List<Cliente> Clientes { get; set; } = new List<Cliente>()
        {
            new Cliente()
            {
                Id = 1,
                Cedula = "12345",
                Nombre = "Juan",
                Apellido = "Thomas",
                Correo = "juanthomas@email.com",
                Licencia = "12345",
                Nacionalidad = "Dominicano",
                TipoDeSangre = "A+",
            },
            new Cliente()
            {
                Id = 2,
                Cedula = "123456",
                Nombre = "Pedro",
                Apellido = "Cisco",
                Correo = "pedrocisco@email.com",
                Licencia = "123456",
                Nacionalidad = "Dominicano",
                TipoDeSangre = "A-",
            },
            new Cliente()
            {
                Id = 3,
                Cedula = "123457",
                Nombre = "Kiko",
                Apellido = "Estufa",
                Correo = "kikoestufa@email.com",
                Licencia = "123457",
                Nacionalidad = "Dominicano",
                TipoDeSangre = "B+",
            }
        };

        public List<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>
        {
            new Vehiculo
            {
                Id = 1,
                TipoVehiculo = new TipoVehiculo { Id = 3 } ,
                Marca = "Nissan",
                Modelo = "Plop",
                Year = 2010,
                Color = "Negro",
                PrecioPorDia = 1000,
                CapacidadDeCarga = 23,
                Pasajeros = 4,
                Matricula = "12345",
                NoSeguro = "12345",
                Latitud = 23.894764m,
                Longitud = 23.482638m
            },
            new Vehiculo
            {
                Id = 2,
                TipoVehiculo = new TipoVehiculo { Id = 2 } ,
                Marca = "Toyota",
                Modelo = "Sonata",
                Year = 2011,
                Color = "Rojo",
                PrecioPorDia = 1001,
                CapacidadDeCarga = 24,
                Pasajeros = 4,
                Matricula = "123456",
                NoSeguro = "123456",
                Latitud = 29.894764m,
                Longitud = 29.482638m
            },
            new Vehiculo
            {
                Id = 3,
                TipoVehiculo = new TipoVehiculo { Id = 1 } ,
                Marca = "Audi",
                Modelo = "IronMan",
                Year = 2012,
                Color = "Gris",
                PrecioPorDia = 1002,
                CapacidadDeCarga = 23,
                Pasajeros = 4,
                Matricula = "123457",
                NoSeguro = "123457",
                Latitud = 25.894764m,
                Longitud = 25.482638m
            }
        };

        public List<TipoVehiculo> TipoVehiculo { get; set; } = new List<TipoVehiculo>
        {
            new TipoVehiculo
            {
                Id = 1,
                Nombre ="Carro"
            },
            new TipoVehiculo
            {
                Id = 2,
                Nombre ="Camion"
            },
            new TipoVehiculo
            {
                Id = 3,
                Nombre ="Jeepeta"
            },
            new TipoVehiculo
            {
                Id = 4,
                Nombre ="Avion"
            },
            new TipoVehiculo
            {
                Id = 5,
                Nombre ="Barco"
            },
        };

        public List<Reserva> Reservas { get; set; } = new List<Reserva>
        {
            new Reserva
            {
                Vehiculo = new Vehiculo {Id = 1},
                Cliente = new Cliente {Id = 1},
                FechaInicio = DateTime.Now,
                FechaFin = DateTime.Now.AddDays(10),
                Id = 1
            },
            new Reserva
            {
                Vehiculo = new Vehiculo {Id = 2},
                Cliente = new Cliente {Id = 2},
                FechaInicio = DateTime.Now,
                FechaFin = DateTime.Now.AddDays(10),
                Id = 2
            },
            new Reserva
            {
                Vehiculo = new Vehiculo {Id = 3},
                Cliente = new Cliente {Id = 3},
                FechaInicio = DateTime.Now,
                FechaFin = DateTime.Now.AddDays(10),
                Id = 3
            },
        };
    }
}
