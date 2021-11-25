using System;

namespace Fifa.Core
{
    public class Transferecia
    {
        public DateTime Publicacion { get; set; }
        public uint Precio { get; set; }
        public DateTime Compra { get; set; }
        public Usuario IdComprador { get; set; }
        public Usuario IdVendedor { get; set; }
        public Futbolista IdFutbolista { get; set; }
    }
}