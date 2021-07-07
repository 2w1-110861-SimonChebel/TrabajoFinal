using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class DetallePedido
    {
        public int idDetallePedido { get; set; }
        public Producto producto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; } = 0;
        public decimal iva { get; set; } = 0;
        public decimal subTotal { get; set; }

        public DetallePedido()
        {
            producto = new Producto();
        }
    }
}