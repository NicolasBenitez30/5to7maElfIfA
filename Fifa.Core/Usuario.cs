namespace Fifa.Core
{
    public class Usuario
    {
        public int id { get; set; }
        public string nombreDeUsuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string contrasena { get; set; }
        public uint monedas { get; set; }
        public List<Futbolista> futbolistas { get; set; }
    }
}