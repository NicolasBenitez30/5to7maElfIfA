using System;
using et12.edu.ar.MenuesConsola;
using System.Collections.Generic;
using Fifa.Core;

namespace Admin.Consola.Menu
{
    public class MenuListaPosicion: MenuListador<Posicion>
    {
        public override void imprimirElemento(Posicion elemento)
        {
            Console.WriteLine($"{elemento.Nombre}");
        }
        public override List<Posicion> obtenerLista() => Program.Ado.ObtenerPosiciones();
    }
}