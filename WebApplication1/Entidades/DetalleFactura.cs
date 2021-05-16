using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class DetalleFactura
    {
        public int idDetalle { get; set; } = 0;
        public int cantidad { get; set; } = 0;
        public Producto producto { get; set; } = null;
        public float iva { get; set; } = 0;
        public float subTotal { get; set; }

        public DetalleFactura()
        {
            producto = new Producto();
        }
    }
}