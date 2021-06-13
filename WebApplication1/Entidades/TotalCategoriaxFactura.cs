using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class TotalCategoriaxFactura
    {
        public Factura factura { get; set; } = null;
        public Categoria categoria { get; set; } = null;

        public TotalCategoriaxFactura()
        {
            
        }
    }
}