using System;
using Radzen;

namespace SuperAlquiler.Pages.Utilidades
{
    public class Marcador
    {
        public string Titulo { get; set; }
        public string Etiqueta { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        private GoogleMapPosition _posicion = new GoogleMapPosition();
        public GoogleMapPosition Posicion
        {
            get
            {
                _posicion.Lat = Latitud;
                _posicion.Lng = Longitud;
                return _posicion;
            }
        }
    }
}
