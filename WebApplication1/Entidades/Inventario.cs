using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class Inventario
    {
        public int idInventario { get; set; } = 0;
        public Producto producto { get; set; } = null;
        public EstadoProducto estado { get; set; } = null;
        public Inventario()
        {
            this.producto = new Producto();
            this.estado = new EstadoProducto();
        }
    }
}