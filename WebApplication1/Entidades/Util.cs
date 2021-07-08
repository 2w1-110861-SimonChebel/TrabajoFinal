using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Easy_Stock.Entidades
{
    public static class Util
    {
        public static int rango { get; } = 30;
        public static void CargarComboYears(ref DropDownList ddl)
        {
            int yearRange = DateTime.Today.Year - rango;

            for (int i = 0; i <= rango; i++)
            {
                ListItem li = new ListItem
                {
                    Text = yearRange.ToString(),
                    Value = yearRange.ToString()
                };
                ddl.Items.Add(li);
                yearRange++;
            }

        }


        public static List<DetalleFactura> AgruparDetallePorProducto(List<DetalleFactura> lstDetalle)
        {
            List<DetalleFactura> lstResultado = new List<DetalleFactura>();
            int ultimoIdProducto = 0;
            foreach (var detalle in lstDetalle)
            {
                if (ultimoIdProducto != 0 && detalle.producto.idProducto == ultimoIdProducto)
                {
                    continue;
                }
                else
                {
                    ultimoIdProducto = detalle.producto.idProducto;
                    int cantidad = lstDetalle.Where(p => p.producto.idProducto == detalle.producto.idProducto).Count();
                    DetalleFactura auxDetalle = new DetalleFactura { producto = new Producto { nombre = detalle.producto.nombre }, precio = detalle.producto.precioVenta, subTotal = detalle.producto.precioVenta * cantidad, cantidad = cantidad };
                    lstResultado.Add(auxDetalle);
                }
            }

            return lstResultado;
        }


        public static List<DetallePedido> AgruparDetallePedidoPorProducto(List<DetallePedido> lstDetalle)
        {
            List<DetallePedido> lstResultado = new List<DetallePedido>();
            int ultimoIdProducto = 0;
            foreach (var detalle in lstDetalle)
            {
                if (ultimoIdProducto != 0 && detalle.producto.idProducto == ultimoIdProducto)
                {
                    continue;
                }
                else
                {
                    ultimoIdProducto = detalle.producto.idProducto;
                    int cantidad = lstDetalle.Where(p => p.producto.idProducto == detalle.producto.idProducto).Count();
                    DetallePedido auxDetalle = new DetallePedido { producto = new Producto {idProducto=detalle.producto.idProducto, nombre = detalle.producto.nombre }, precio = detalle.producto.precioCosto, subTotal = detalle.producto.precioCosto * cantidad, cantidad = cantidad };
                    lstResultado.Add(auxDetalle);
                }
            }

            return lstResultado;
        }

    }
}