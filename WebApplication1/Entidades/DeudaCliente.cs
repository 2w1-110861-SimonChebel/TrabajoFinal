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
        public decimal montoAfavor { get; set; } = 0;

        public DeudaCliente()
        {
            idDeudaCliente = 0;
            monto = 0;
            montoAfavor = 0;
        }
    }
}