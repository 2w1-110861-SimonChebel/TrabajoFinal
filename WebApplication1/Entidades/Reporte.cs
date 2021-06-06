using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class Reporte
    {
        public Query query { get; set; } = null;
        public Reporte()
        {
            query = new Query();
        }
    }
}