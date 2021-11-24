using System.Collections.Generic;

namespace Fifa.Core
{
    public interface IAdo
    {
        
        void AltaPosicion(Posicion Posicion);
        void AltaHabiliadad(Habilidad Habilidad);

        List<Posicion> ObtenerPosiciones();
        List<Habilidad> ObtenerHabilidades();

    }
}