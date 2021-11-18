using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System;
using System.Data;
using System.Collections.Generic;

namespace Fifa.AdoMySQL.Mapeadores
{
    public class MapHabilidad : Mapeador<Habilidad>
    {
        public MapHabilidad(AdoAGBD ado):base(ado)
        {
            Tabla = "Habiliadad";
        }
        public override Habilidad ObjetoDesdeFila(DataRow fila)
            => new Habilidad()
            {
                Id = Convert.ToByte(fila["idHabilidad"]),
                Habilidad = fila["habilidad"].ToString(),
                Descripcion = fila["descripcion"].ToString()
            };

        public void AltaHabiliadad(Habilidad habilidad)
            => EjecutarComandoCon("altaHabilidad", ConfigurarAltaHabiliadad, PostAltaHabilidad, habilidad);

        public void ConfigurarAltaHabiliadad(Habiliadad habilidad)
        {
            SetComandoSP("altaHabilidad");

            BP.CrearParametroSalida("unIdHabilidad")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
              .AgregarParametro();

            BP.CrearParametro("unHabilidad")
              .SetTipoVarchar(45)
              .SetValor(Habiliadad.Habiliadad)
              .AgregarParametro();
        }

        public void PostAltaHabilidad(Habiliadad Habiliadad)
        {
            var paramId = GetParametro("unId");
            Habiliadad.Id = Convert.ToByte(paramId.Value);
        }

        public List<Habiliadad> ObtenerHabilidad() => ColeccionDesdeTabla();
    }
}