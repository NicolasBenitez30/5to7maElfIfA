using System.Collections.Generic;
using et12.edu.ar.AGBD.Ado;
using Fifa.Core;
using Fifa.AdoMySQL.Mapeadores;

namespace Fifa.AdoMySQL
{
    public class AdoFifa: IAdo
    {
        public AdoAGBD Ado { get; set; }
        public MapHabilidad MapHabilidad { get; set; }

        public MapPosicion MapPosicion { get; set; }
        public AdoFifa(AdoAGBD ado)
        {
            Ado = ado;
            MapHabilidad = new MapHabilidad(Ado);
            MapPosicion = new MapPosicion(Ado);
        }
        public void AltaHabiliadad(Habilidad habiliadad) => MapHabilidad.AltaHabilidad(habiliadad);
        public List<Habilidad> ObtenerHabilidades() => MapHabilidad.ObtenerHabilidades();

        public void AltaPosicion(Posicion Posicion) => MapPosicion.AltaPosicion(Posicion);

        public List<Posicion> ObtenerPosiciones() => MapPosicion.ObtenerPosiciones();
    }
}