using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class Transaccion
    {
        public int idTransaccion { get; set; } = 0;
        public DateTime fecha { get; set; } = DateTime.Now;
        public string descripcion { get; set; } = string.Empty;
        public Proveedor proveedor { get; set; } = null;
        public float descuento { get; set; } = 0;
        public float total { get; set; } = 0;
        public FormaPago formaPago { get; set; } = null;
        public TipoTransaccion tipoTransaccion { get; set; } = null;

        public Transaccion()
        {
            this.proveedor = new Proveedor();
            this.formaPago = new FormaPago();
            this.tipoTransaccion = new TipoTransaccion();
        }
    }
}