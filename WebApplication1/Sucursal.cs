using Easy_Stock.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock
{
    public class Sucursal
    {
        public int idSucursal { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public Deposito deposito { get; set; }
        public Localidad localidad { get; set; }
        public Provincia provinica { get; set; }
    }
}