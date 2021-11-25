using et12.edu.ar.AGBD.Ado;
using System;
using Fifa.Core;
using Fifa.AdoMySQL;
using Admin.Consola.Menu;
using et12.edu.ar.MenuesConsola;

namespace Admin.Consola
{
    public class Program
    {
        public static IAdo Ado {get; private set;}
        static void Main(string[] args)
        {
            var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "root");
            Ado = new AdoFifa(adoAGBD);

            var MenuAltaHabilidad = new MenuAltaHabilidad() { Nombre = "Alta Habilidad" };
            var MenuListaHabilidad = new MenuListaHabilidad() { Nombre = "Listado Habilidades" };
            var MenuAltaPosicion = new MenuAltaPosicion() { Nombre = "Alta Posicion" };
            var MenuListaPosicion = new MenuListaPosicion() { Nombre = "Listado Posiciones" };

            var menuHabilidad = new MenuCompuesto() { Nombre = "Habilidades" };
            menuHabilidad.agregarMenu(MenuAltaHabilidad);
            menuHabilidad.agregarMenu(MenuListaHabilidad);

            var menuPosicion = new MenuCompuesto() { Nombre = "Posiciones" };
            menuPosicion.agregarMenu(MenuAltaPosicion);
            menuPosicion.agregarMenu(MenuListaPosicion);

            var menuPrincipal = new MenuCompuesto() { Nombre = "Menu Admin" };
            menuPrincipal.agregarMenu(menuHabilidad);
            menuPrincipal.agregarMenu(menuPosicion);

            menuPrincipal.mostrar();
        }       

    }
}
