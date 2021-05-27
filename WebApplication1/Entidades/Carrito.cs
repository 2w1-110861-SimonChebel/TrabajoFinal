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

        public decimal calcularTotal()
        {
            decimal total = 0;
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

        public decimal calcularPrecioConIva()
        {
            return 0;
        }

        public void agregarProducto(Producto producto)
        {
            foreach (var prod in productos)
            {
                if (prod.idProducto == producto.idProducto)
                {
                    prod.cantidad += producto.cantidad;
                    return;
                }
            }
            this.productos.Add(producto);
        }

        public List<Producto> mostrarProductosCarrito()
        {
            List<Producto> lst = new List<Producto>();
            Producto oProducto = new Producto();
            int cont = 0;
            for(int i= 0;i< productos.Count; i++)
            {
                Producto prod = productos[i];
                if (cont == 0) { oProducto = prod; lst.Add(oProducto); cont++; }
                else
                {
                    if (prod.idProducto == oProducto.idProducto)
                    {
                       oProducto.cantidad += prod.cantidad;
                       lst.Add(oProducto);
                    }
                    else {
                        if (!lst.Exists(p => p.idProducto == prod.idProducto))
                        {
                            oProducto = prod;
                            lst.Add(oProducto);
                            cont++;
                        }
                    }
                
                }
           
            }

            return lst;

        }

        public decimal calculcarSubTotalProducto(int idProducto)
        {
            foreach (var item in productos)
            {
                if (item.idProducto == idProducto) return item.calcularSubTotal();
            }
            return 0;
        }
        public decimal calcularTotalProductos()
        {
            decimal total = 0;
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