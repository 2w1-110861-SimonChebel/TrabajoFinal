using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class Proveedor
    {
        public int idProveedor { get; set; } = 0;
        public string nombre { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string telefono { get; set; } = string.Empty;
        public string codigoPostal { get; set; } = string.Empty;
        public string barrio { get; set; } = string.Empty;
        public Localidad localidad { get; set; } = null;
        public Provincia provincia { get; set; } = null;

        public Proveedor() {
            idProveedor = 0;
            nombre = string.Empty;
            email = string.Empty;
            telefono = string.Empty;
            codigoPostal = string.Empty;
            barrio = string.Empty;
            localidad = new Localidad();
            provincia = new Provincia();
        }

    }
}