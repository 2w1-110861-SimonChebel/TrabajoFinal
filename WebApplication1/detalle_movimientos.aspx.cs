using Easy_Stock.AccesoDatos;
using Easy_Stock.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Easy_Stock
{
    public partial class detalle_movimientos : System.Web.UI.Page
    {
        protected Transaccion oTransaccion;
        protected VentaCliente oVenta;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idTran = Convert.ToInt32(Request.QueryString["id"]);
                int idTipoTran = Convert.ToInt32(Request.QueryString["idTipo"]);

                switch (idTipoTran)
                {
                    case (int)Tipo.tipoTransaccion.ventaCliente:
                        oVenta = AdTransaccion.obtenerDetalleVentaCliente(idTran, idTipoTran).First();
                        oVenta.factura.detallesFactura = AgruparDetallePorProducto(oVenta.factura.detallesFactura);
                        hNroTran.InnerText = string.Format("{0}{1}",hNroTran.InnerText,oVenta.idTransaccion);
                        hFecha.InnerText = string.Format("{0}{1}",hFecha.InnerText,oVenta.fecha.ToString());
                        hCliente.InnerText = oVenta.cliente.tipoCliente.idTipoCliente == (int)Tipo.tipoCliente.persona ?
                            string.Format("{0}{1} {2}", hCliente.InnerText, oVenta.cliente.nombre, oVenta.cliente.apellido) :
                            string.Format("{0}{1}", hCliente.InnerText, oVenta.cliente.razonSocial);
                        hOperador.InnerText = string.Format("{0}{1} {2}",hOperador.InnerText, oVenta.usuario.nombre,oVenta.usuario.apellido);
                        break;
                    case (int)Tipo.tipoTransaccion.cambioProductoDeCliente:

                        break;
                    default:
                        break;
                }
            }
        }

        private List<DetalleFactura> AgruparDetallePorProducto(List<DetalleFactura> lstDetalle)
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
            //lstResultado = (from detalle in lstResultado
            //                group detalle by new {detalle.producto,detalle.precio,detalle.subTotal,detalle.cantidad} into d
            //                select new DetalleFactura()
            //                { 
            //                    producto = d.Key.producto,
            //                    precio = d.Key.precio,
            //                    subTotal = d.Key.subTotal,
            //                    cantidad = d.Key.cantidad  

            //                }).ToList();
            
            return lstResultado; 
        }
    }
}