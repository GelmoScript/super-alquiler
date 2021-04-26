using System;
using Radzen;

namespace SuperAlquiler.Entities
{
    public class Vehiculo : EntidadBase, IClonador<Vehiculo>
    {
        public Vehiculo()
        {
            TipoVehiculo = new TipoVehiculo();
        }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Matricula { get; set; }
        public string NoSeguro { get; set; }
        public int Year { get; set; }
        public decimal PrecioPorDia { get; set; }
        public decimal CapacidadDeCarga { get; set; }

        public TipoVehiculo TipoVehiculo { get; set; }
        public string Color { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public int Pasajeros { get; set; }
        public byte[] Foto { get; set; }
        public string Ubicacion {
            get
            {
                return $"{Latitud}, {Longitud}";
            }
        }

        private GoogleMapPosition _posicion = new GoogleMapPosition();
        public GoogleMapPosition Posicion
        {
            get
            {
                _posicion.Lat = decimal.ToDouble(Latitud);
                _posicion.Lng = decimal.ToDouble(Longitud);
                return _posicion;
            }
        }

        public override string ToString()
        {
            return $"[{Matricula}] {Marca}-{Modelo} {Color}";
        }

        public Vehiculo Clonar()
        {
            Vehiculo vehiculo = (Vehiculo)MemberwiseClone();
            vehiculo.TipoVehiculo = new TipoVehiculo { Id = TipoVehiculo.Id };
            return vehiculo;
        }
    }
}
