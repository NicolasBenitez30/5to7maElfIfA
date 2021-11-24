using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System;
using System.Data;
using System.Collections.Generic;
using Fifa.Core;

namespace Fifa.AdoMySQL.Mapeadores
{
    public class MapPosicion : Mapeador<Posicion>
    {
        public MapPosicion(AdoAGBD ado): base(ado)
        {
            Tabla = "Posicion";
        }

        public override Posicion ObjetoDesdeFila(DataRow fila)
                => new Posicion()
        {
            Id = Convert.ToSByte(fila["idPosicion"]),
            Nombre = fila["Posicion"].ToString()
        };

        public void AltaPosicion(Posicion posicion)
            => EjecutarComandoCon("altaPosicion", ConfigurarAltaPosicion, PostAltaPosicion, posicion);

        public void ConfigurarAltaPosicion(Posicion posicion)
        {
            SetComandoSP("altaPosicion");

            BP.CrearParametroSalida("unidPosicon")
              .SetTipo(MySql.Data.MySqlClient.MySqlDbType.UByte)
              .AgregarParametro();

            BP.CrearParametro("unaPosicion")
              .SetTipoVarchar(45)
              .SetValor(posicion.Nombre)
              .AgregarParametro();
        }
        public void PostAltaPosicion(Posicion posicion)
        {
            var paramId = GetParametro("unidPosicion");
            posicion.Id = Convert.ToSByte(paramId.Value);
        }

        public List<Posicion> ObtenerPosiciones() => ColeccionDesdeTabla();
    }
}