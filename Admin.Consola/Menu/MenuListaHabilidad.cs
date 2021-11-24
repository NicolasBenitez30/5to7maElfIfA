using Fifa.Core;
using System;
using et12.edu.ar.MenuesConsola;
using System.Collections.Generic;

namespace Admin.Consola.Menu
{
    public class MenuListaHabilidad : MenuListador<Habilidad>
    {
        public override void imprimirElemento(Habilidad elemento)
        {
            Console.WriteLine($"{elemento.Nombre}\t\t{elemento.Descripcion}");
        }
        public override List<Habilidad> obtenerLista() => Program.Ado.ObtenerHabilidades();
    }
}