using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class CompraProveedor : Transaccion
    {
        public Factura factura { get; set; } = null;

        public Empresa destinatario { get; set; } = null;

        public Pedido pedido { get; set; } = null;

        public CompraProveedor() : base() 
        { 
            factura = new Factura();
            destinatario = new Empresa();
            proveedor = new Proveedor();
            pedido = new Pedido();

        }
    }

}