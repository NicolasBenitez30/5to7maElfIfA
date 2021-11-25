using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System;
using System.Data;
using System.Collections.Generic;
using Fifa.Core;

namespace Fifa.AdoMySQL.Mapeadores
{
    public class MapHabilidad : Mapeador<Habilidad>
    {
        public MapHabilidad(AdoAGBD ado):base(ado)
        {
            Tabla = "Habilidad";
        }
        public override Habilidad ObjetoDesdeFila(DataRow fila)
            => new Habilidad()
            {
                Id = Convert.ToSByte(fila["idHabilidad"]),
                Nombre = fila["habilidad"].ToString(),
                Descripcion = fila["descripcion"].ToString()
            };

        public void AltaHabilidad(Habilidad habilidad)
            => EjecutarComandoCon("altaHabilidad", ConfigurarAltaHabilidad, PostAltaHabilidad, habilidad);

        public void ConfigurarAltaHabilidad(Habilidad habilidad)
        {
            SetComandoSP("altaHabilidad");

            BP.CrearParametroSalida("unIdHabilidad")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
              .AgregarParametro();

            BP.CrearParametro("unHabilidad")
              .SetTipoVarchar(45)
              .SetValor(habilidad.Nombre)
              .AgregarParametro();

            BP.CrearParametro("unDescripcion")
              .SetTipoVarchar(45)
              .SetValor(habilidad.Descripcion)
              .AgregarParametro();

        }

        public void PostAltaHabilidad(Habilidad Habilidad)
        {
            var paramId = GetParametro("unIdHabilidad");
            Habilidad.Id = Convert.ToSByte(paramId.Value);
        }

        public List<Habilidad> ObtenerHabilidades() => ColeccionDesdeTabla();
    }
}