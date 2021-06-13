using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class ReVenta : Reporte
    {

        public List<TotalCategoriaxFactura> totalesCategoriasxFactura;
        public List<TotalPorProducto> totalesProductosxFactura;
        public ReVenta() : base() 
        {
            totalesCategoriasxFactura = new List<TotalCategoriaxFactura>();
            totalesProductosxFactura = new List<TotalPorProducto>();
        }

        public decimal CalcularTotalPorCategoria()
        {
            decimal resultado = 0;

            foreach (var item in totalesCategoriasxFactura)
            {
                resultado += item.factura.total;
            }
            return resultado;
        }
    }
}