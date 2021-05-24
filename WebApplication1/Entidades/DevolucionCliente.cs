using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class DevolucionCliente
    {
        public int idDevolucion { get; set; } = 0;
        VentaCliente ventaCliente { get; set; } = null;
        public DevolucionCliente()
        {
            ventaCliente = new VentaCliente();
        }
    }
}