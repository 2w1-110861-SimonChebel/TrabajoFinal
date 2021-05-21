using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class VentaCliente : Transaccion
    {
        public Factura factura { get; set; } = null;
        public Cliente cliente { get; set; } = null;
        public VentaCliente() : base()
        {
            this.factura = new Factura();
            this.cliente = new Cliente();
        }
    }
}