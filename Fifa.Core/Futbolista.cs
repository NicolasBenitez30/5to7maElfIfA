using System;
using System.Collections.Generic;

namespace Fifa.Core
{
    public class Futbolista
    {
        public short id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime nacimiento { get; set; }
        public byte velocidad { get; set; }
        public byte disparo { get; set; }
        public byte pase { get; set; }
        public byte defensa { get; set; }
        public Posicion id { get; set; }
        public List<Habilidad> habilidades { get; set }
    }
}