using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class Carrito
    {
        public List<Producto> productos { get; set; } = null;
        public Cliente cliente { get; set; } = null;
        public Carrito()
        {
            this.productos = new List<Producto>();
            this.cliente = new Cliente();
        }

        public float calcularTotal()
        {
            float total = 0;
            foreach (Producto producto in productos)
            {
                total += producto.precioVenta;
            }
            return total;
        }

        public int devolverCantidadProducto(int idProducto)
        {
            foreach (Producto producto in productos)
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
            foreach (var prod in productos)
            {
                if (prod.idProducto == producto.idProducto) { 
                    prod.cantidad += producto.cantidad;
                    return;
                }
            }
            this.productos.Add(producto);
        }

        public float calculcarSubTotalProducto(int idProducto)
        {
            foreach (var item in productos)
            {
                if (item.idProducto == idProducto) return item.calcularSubTotal();
            }
            return 0;
        }
        public float calcularTotalProductos()
        {
            float total = 0;
            foreach (var item in productos)
            {
                total += item.calcularSubTotal();
            }
            return total;
        }

        public bool removerProducto(int idProducto)
        {
            foreach (var item in productos)
            {
                if (item.idProducto == idProducto) { 
                    productos.Remove(item);
                    return true;
                }
            }
            return false;
        }
    }
}