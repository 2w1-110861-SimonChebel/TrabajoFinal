using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class Carrito
    {
        public List<Producto> lstProductos { get; set; } = null;
        public Carrito()
        {
            this.lstProductos = new List<Producto>();
        }

        public float calcularTotal()
        {
            float total = 0;
            foreach (Producto producto in lstProductos)
            {
                total += producto.precioVenta;
            }
            return total;
        }

        public int devolverCantidadProducto(int idProducto)
        {
            int cantidad = 0;
            foreach (Producto producto in lstProductos)
            {
                if (producto.idProducto == idProducto) cantidad++;
            }
            return cantidad;
        }

        public float calcularPrecioConIva()
        {
            return 0;
        }
    }
}