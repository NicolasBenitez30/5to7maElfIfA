using System;
using System.Collections.Generic;

namespace Fifa.Core
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreDeUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contrasena { get; set; }
        public uint Monedas { get; set; }
        public List<Futbolista> Futbolistas { get; set; }

        public Usuario()
        {
            Futbolistas = new List<Futbolista>();
        }
    }
}