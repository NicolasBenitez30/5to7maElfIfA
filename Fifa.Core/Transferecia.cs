using System;

namespace Fifa.Core
{
    public class Transferecia
    {
        public DateTime publicacion { get; set; }
        public uint precio { get; set; }
        public DateTime compra { get; set; }
        public Usuario idComprador { get; set; }
        public Usuario idVendedor { get; set; }
        public Futbolista idFutbolista { get; set; }
    }
}