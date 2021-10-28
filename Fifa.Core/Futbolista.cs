using System;
using System.Collections.Generic;

namespace Fifa.Core
{
    public class Futbolista
    {
        public int idFutbolista;

        public string nombreF;

        public string apellidoF;

        public DateTime nacimiento;

        public int velocidad;

        public int disparo;

        public int pase;

        public int defensa;

        public Posicion idPosicon;

        public List<Habilidad> idHabilidad;
    }
}