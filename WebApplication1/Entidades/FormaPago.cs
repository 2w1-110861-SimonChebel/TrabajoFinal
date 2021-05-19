using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class FormaPago
    {
        public int idFormaPago { get; set; } = 0;
        public string formaPago { get; set; } = string.Empty;
        public int porcentajeRecargo { get; set; } = 0;

        public FormaPago()
        {
            
        }
    }
}