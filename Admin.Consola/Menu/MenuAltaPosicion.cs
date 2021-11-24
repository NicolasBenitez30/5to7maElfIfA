using Fifa.Core;
using System;
using et12.edu.ar.MenuesConsola;

namespace Admin.Consola.Menu
{
    public class MenuAltaPosicion: MenuComponente
    {
        public Posicion Posicion { get; set;}

        public override void mostrar()
        {
            base.mostrar();

            var nombre = prompt("Ingrese Nombre Posicion");

            Posicion = new Posicion()
            {
                Nombre = nombre
            };

            try
            {
                Program.Ado.AltaPosicion(Posicion);
                Console.WriteLine("Posicion dada de alta con exito");
            }
            catch (Exception e)
            {
                Console.WriteLine($"No se pudo dar de alta: {e.Message}");
            }
            Console.ReadKey();
        }
    }
}