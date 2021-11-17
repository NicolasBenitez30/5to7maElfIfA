using System.Collections.Generic;
using Fifa.Core;

namespace 
{
    public interface IAdo
    {
        
        void AltaPosicion(Posicion Posicion);
        void AltaHabiliadad(Habilidad Habilidad);

        List<Posicion> ObtenerPosiciones();
        List<Habilidades> ObtenerHabilidades();

    }
}