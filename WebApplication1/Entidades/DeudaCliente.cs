using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class DeudaCliente
    {
        public int idDeudaCliente { get; set; } = 0;
        public decimal monto { get; set; } = 0;

        public DeudaCliente()
        {
            this.idDeudaCliente = 0;
            this.monto = 0;
        }
    }
}