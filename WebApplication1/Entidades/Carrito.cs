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
            foreach (Producto producto in lstProductos)
            {
                if (producto.idProducto == idProducto) return producto.cantidad;
            }
            return 0;
        }

        public float calcularPrecioConIva()
        {
            return 0;
        }

        public void agregarProducto(Producto producto)
        {
            foreach (var prod in lstProductos)
            {
                if (prod.idProducto == producto.idProducto) { 
                    prod.cantidad += producto.cantidad;
                    return;
                }
            }
            this.lstProductos.Add(producto);
        }

        public float calculcarSubTotalProducto(int idProducto)
        {
            foreach (var item in lstProductos)
            {
                if (item.idProducto == idProducto) return item.calcularSubTotal();
            }
            return 0;
        }
        public float calcularTotalProductos()
        {
            float total = 0;
            foreach (var item in lstProductos)
            {
                total += item.calcularSubTotal();
            }
            return total;
        }

        public bool removerProducto(int idProducto)
        {
            foreach (var item in lstProductos)
            {
                if (item.idProducto == idProducto) { 
                    lstProductos.Remove(item);
                    return true;
                }
            }
            return false;
        }
    }
}