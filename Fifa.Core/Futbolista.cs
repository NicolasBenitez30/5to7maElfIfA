using System;
using System.Collections.Generic;

namespace Fifa.Core
{
    public class Futbolista
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime nacimiento { get; set; }
        public int velocidad { get; set; }
        public int disparo { get; set; }
        public int pase { get; set; }
        public int defensa { get; set; }
        public Posicion idPosicon { get; set; }
        public List<Habilidad> habilidades { get; set }
    }
}