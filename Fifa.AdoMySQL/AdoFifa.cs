using System.Collections.Generic;
using et12.edu.ar.AGBD.Ado;

namespace Fifa.AdoMySQL
{
    public class AdoFifa
    {
        public AdoAGBD Ado { get, set; }
        public MapHabilidad MapHabilidad { get; set; }
        public AdoFifa(AdoAGBD ado)
        {
            Ado = ado;
            MapHabilidad = new MapHabilidad(Ado);
        }
        public void AltaHabiliadad(Habiliadad Habiliadad) => MapHabilidad.AltaHabiliadad(Habiliadad);
        public List<Habiliadad> ObtenerHabilidad() => MapHabilidad.ObtenerHabilidad();

    }
}