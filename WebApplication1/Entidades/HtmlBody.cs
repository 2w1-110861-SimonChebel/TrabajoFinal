using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public static class HtmlBody
    {
        public static string BodyClientePorVentaCliente { get; } = ("<body> <h1> Muchas gracias por elegirnos @cliente</h1> <br> " +
               "<h4>Le hacemos llegar este email con los detalles de su compra: </h4> </body>");

        public static string BodyUsuarioPorVentaCliente { get; } = ("<body> <h1> @usuario realizaste la siguiente transaccion: </h1> <br> " +
              "<h4>Este es un mail de prueba que le llega al operador que realiza la transacción </h4> </body>");

        public static string AsuntoClientePorVentaCliente { get; } = "Resumen de compra Easy Stock";
        public static string AsuntoUsuarioPorVentaCliente { get; } = "Transaccion realizada";


    }
}