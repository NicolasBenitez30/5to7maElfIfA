﻿using et12.edu.ar.AGBD.Ado;
using System;

namespace Admin.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            var adoAGBD = FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test");
        }
    }
}
