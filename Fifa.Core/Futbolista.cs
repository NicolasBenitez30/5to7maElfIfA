using System;
using System.Collections.Generic;

namespace Fifa.Core
{
    public class Futbolista
    {
        public short Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Nacimiento { get; set; }
        public byte Velocidad { get; set; }
        public byte Disparo { get; set; }
        public byte Pase { get; set; }
        public byte Defensa { get; set; }
        public Posicion Posicion { get; set; }
        public List<Habilidad> Habilidades { get; set; }

        public Futbolista()
        {
            Habilidades = new List<Habilidad>();
        }
    }
}