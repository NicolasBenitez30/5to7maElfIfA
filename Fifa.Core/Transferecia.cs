using System;

namespace Fifa.Core
{
    public class Transferecia
    {
        public DateTime publicacion { get; set; }
        public uint precio { get; set; }
        public DateTime compra { get; set; }
        public Usuario Comprador { get; set; }
        public Usuario Vendedor { get; set; }
        public Futbolista id { get; set; }
    }
}