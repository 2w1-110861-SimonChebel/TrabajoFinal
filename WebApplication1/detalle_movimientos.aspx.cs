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
        protected CambioProducto oCambio;
        protected Devolucion oDevolucion;
        protected VentaCliente oVenta;
        protected CompraProveedor oCompra;
        protected int idTran;
        protected int idTipoTran;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                idTran = Request.QueryString["id"] != null ? Convert.ToInt32(Request.QueryString["id"]): 0;
                idTipoTran = Request.QueryString["idTipo"]!=null? Convert.ToInt32(Request.QueryString["idTipo"]): 0;

                switch (idTipoTran)
                {
                    case (int)Tipo.tipoTransaccion.ventaCliente:
                        oVenta = AdTransaccion.ObtenerDetalleVentaCliente(idTran, idTipoTran).First();
                        oVenta.factura.detallesFactura = Util.AgruparDetallePorProducto(oVenta.factura.detallesFactura);//AgruparDetallePorProducto(oVenta.factura.detallesFactura);
                        MostrarInfoCabecera(oVenta);
                        break;

                    case (int)Tipo.tipoTransaccion.cambioProductoDeCliente:
                        oCambio = AdTransaccion.ObtenerDetalleCambioProducto(idTran,idTipoTran);
                        MostrarInfoCabecera(oCambio);    
                        break;

                    case (int)Tipo.tipoTransaccion.devolucionDeCliente:
                        oCambio = AdTransaccion.ObtenerDetalleCambioProducto(idTran, idTipoTran);
                        MostrarInfoCabecera(oCambio);
                        break;
                    case (int)Tipo.tipoTransaccion.compraProveedor:
                        oCompra = AdTransaccion.ObtenerDetalleCompraProveedor(idTran, idTipoTran);
                        oCompra.pedido.detallesPedido = Util.AgruparDetallePedidoPorProducto(oCompra.pedido.detallesPedido);
                        MostrarInfoCabecera(oCompra);
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
            
            return lstResultado; 
        }

        private void MostrarInfoCabecera(Transaccion oTran)
        {
            string tipoTran = "";
            switch (idTipoTran)
            {
                case (int)Tipo.tipoTransaccion.ventaCliente:
                    tipoTran = "Venta a cliente";
                    break;

                case (int)Tipo.tipoTransaccion.cambioProductoDeCliente:
                    tipoTran = "Cambio de producto de cliente";
                    break;

                case (int)Tipo.tipoTransaccion.devolucionDeCliente:
                    tipoTran = "Devolución de producto de cliente";
                    break;
                case (int)Tipo.tipoTransaccion.compraProveedor:
                    tipoTran = "Compra a proveedor";
                    break;
                case (int)Tipo.tipoTransaccion.devolucionAproveedor:
                    tipoTran = "Devolucion de producto a proveedor";
                    break;
                case (int)Tipo.tipoTransaccion.cambioProductoAproveedor:
                    tipoTran = "Cambio de producto a proveedor";
                    break;
                default:
                    break;
            }

            hNroTran.InnerText = string.Format("{0}{1}", hNroTran.InnerText, oTran.idTransaccion);
            hFecha.InnerText = string.Format("{0}{1}", hFecha.InnerText, oTran.fecha.ToString());
            hObservaciones.InnerText = string.Format("{0}{1}", hObservaciones.InnerText, oTran.descripcion);
            hCliente.InnerText = oTran.cliente.tipoCliente.idTipoCliente == (int)Tipo.tipoCliente.persona ?
                string.Format("{0}{1} {2}", hCliente.InnerText, oTran.cliente.nombre, oTran.cliente.apellido) :
                string.Format("{0}{1}", hCliente.InnerText, oTran.cliente.razonSocial);
            hOperador.InnerText = "Operador: ";
            hOperador.InnerText = string.Format("{0}{1} {2}", hOperador.InnerText, oTran.usuario.nombre, oTran.usuario.apellido);
            hProveedor.InnerText = string.Format("{0} {1}", hProveedor.InnerText, oTran.proveedor.nombre);
            hTipoMov.InnerText = string.Format("{0} {1}",hTipoMov.InnerText, tipoTran);

            if (oTran.tipoTransaccion.idTipoTransaccion == (int)Tipo.tipoTransaccion.cambioProductoDeCliente ||
               oTran.tipoTransaccion.idTipoTransaccion == (int)Tipo.tipoTransaccion.cambioProductoAproveedor ||
               oTran.tipoTransaccion.idTipoTransaccion == (int)Tipo.tipoTransaccion.devolucionDeCliente
            ) 
            {
                hProductosEntregados.InnerText = string.Format("{0}{1}{2}{3}", hProductosEntregados.InnerText,"(", ((CambioProducto)oTran).productosEntregados.Count().ToString(),")");
                hProductosRecibidos.InnerText = string.Format("{0}{1}{2}{3}", hProductosRecibidos.InnerText,"(", ((CambioProducto)oTran).productosRecibidos.Count().ToString(),")");
            }
            

            //agregado
            //var e =hTotalSinIva.InnerText.Split('$');
            //hTotal.InnerText = oVenta.factura.total.ToString().Replace(".", ",") + Convert.ToDecimal(hTotalSinIva.InnerText.Split('$')[1]);
        }
    }
}