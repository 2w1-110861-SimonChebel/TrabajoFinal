using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public  class PorcentajeVentaTipoCliente
    {
        public int cantidadVentas { get; set; } = 0;
        public  TipoCliente tipoCliente { get; set; } = null;

        public PorcentajeVentaTipoCliente()
        {
            tipoCliente = new TipoCliente();
        }

        //public decimal CalcularPorcentaje()


    }
}