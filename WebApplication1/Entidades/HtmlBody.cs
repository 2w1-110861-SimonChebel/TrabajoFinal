using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Easy_Stock.Entidades
{
    public static class HtmlBody
    {
        public static string BodyClientePorVentaCliente { get; } = ("<body> <h1> Muchas gracias por elegirnos @cliente</h1> <br> " +
               "<h4>Le hacemos llegar este email con los detalles de su compra: </h4> </body>");

        public static string BodyUsuarioPorVentaCliente { get; } = ("<body> <h1> @usuario realizaste la siguiente transaccion: </h1> <br>  </body>");

        public static string AsuntoClientePorVentaCliente { get; } = "Resumen de compra Easy Stock";
        public static string AsuntoUsuarioPorVentaCliente { get; } = "Transaccion realizada";

        public static string AsuntoReestablecerClave { get; } = "Reestablecer contraseña";

        public static string BodyConfirmacionClave { get; } = ("<body> <h1>Reestablecé tu clave en el siguiente link: </h1> <br> " +
              "<h3> <a href='https://localhost:44374/validar.aspx?id=@id'>Reestablecer clave</a> </h3> </body>");

        public static string BodyPorVentaCliente(VentaCliente oVenta)
        {
            StringBuilder sbBody = new StringBuilder("<ul> ");
            //sbBody.Append("<li> Nro transaccion: " + oVenta.factura.nroFactura + "</li> ");
            sbBody.Append("<li> Fecha: " + oVenta.factura.fecha + "</li> ");
            sbBody.Append("<li> Observaciones: " + oVenta.factura.observaciones + "</li> ");
            string nombre = oVenta.cliente.tipoCliente.idTipoCliente == (int)Tipo.tipoCliente.persona ? oVenta.cliente.nombre + " " + oVenta.cliente.apellido : oVenta.cliente.razonSocial;
            sbBody.Append("<li> Cliente: " + nombre + "</li> ");
            sbBody.Append("<li> Operador: " + string.Format("{0} {1}", oVenta.usuario.nombre, oVenta.usuario.apellido) + "</li> ");
            sbBody.Append("</ul> <br>");          
            sbBody.Append(TablaMostrarProductos(oVenta));
            sbBody.Append(string.Format("<h2>Total: ${0} </h2>", oVenta.factura.total));

            return sbBody.ToString();
        }

        private static string TablaMostrarProductos(VentaCliente oVenta) //productos entregados es para cuando se realiza un cambio
        {
            bool primeraVez = true; //para saber si es la primera vez y dibujar la cabecera
            StringBuilder sb = new StringBuilder("<table border='1'>");
            //List<DetalleFactura> lstProductos = Util.AgruparDetallePorProducto(oVenta.factura.detallesFactura);
            if (primeraVez)
            {
                sb.Append(" <caption>Detalle de los productos</caption> <tbody>");
                sb.Append("<tr> <th>Producto</th> <th>Cantidad</th> <th>Precio unitario</th>  <th>Iva</th>  <th>Sub total</th>  </tr>");
                primeraVez = false;
            }
            for (int i = 0; i < oVenta.factura.detallesFactura.Count(); i++)
            {
                var item = oVenta.factura.detallesFactura[i];
                sb.Append(string.Format("<tr> <td>{0}</td> <td>{1}</td> <td>{2}</td>  <td>21</td>  <td>{3}</td>  </tr>", item.producto.nombre, item.cantidad, item.producto.precioVenta, item.subTotal));
            }
            sb.Append(" </tbody> </table>");

            return sb.ToString();
        }



    }
}