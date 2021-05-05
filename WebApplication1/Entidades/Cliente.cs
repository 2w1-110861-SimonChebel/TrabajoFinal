using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class Cliente
    {
        public int idCliente { get; set; } = 0;
        public TipoCliente tipoCliente { get; set; } = new TipoCliente();
        public string telefono { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string direccion { get; set; } = string.Empty;
        public string barrio { get; set; } = string.Empty;
        public Localidad localidad { get; set; } = new Localidad();
        public Provincia provincia { get; set; } = new Provincia();
        public string codigoPostal { get; set; } = string.Empty;
        public DeudaCliente deuda { get; set; } = new DeudaCliente();

        public Cliente()
        {
            
        }


    }
}