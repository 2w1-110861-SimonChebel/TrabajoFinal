using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class ProductoReponer
    {
        public int idProducto { get; set; } = 0;
        public string codigo { get; set; } = string.Empty;
        public string nombre { get; set; } = string.Empty;
        public int cantidadRestante { get; set; } = 0;
    }
}