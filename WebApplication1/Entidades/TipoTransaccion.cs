using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class TipoTransaccion
    {
        public int idTipoTransaccion { get; set; } = 0;
        public string tipoTransaccion { get; set; } = string.Empty;

        public enum ITipoTransaccion { 
            ventaCliente = 1,
            compraProveedor = 2
        }
    }
}