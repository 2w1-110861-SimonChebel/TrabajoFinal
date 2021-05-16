using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class Factura
    {
        public int nroFactura { get; set; } = 0;
        public DateTime fecha { get; set;} = DateTime.Now;
        public float total { get; set; } = 0;
        public string observaciones { get; set; } = string.Empty;
        public List<DetalleFactura> detallesFactura { get; set; } = null;
        public TipoFactura tipoFactura { get; set; } = null;

        public Factura()
        {
            detallesFactura = new List<DetalleFactura>();
            tipoFactura = new TipoFactura();
        }

    }
}