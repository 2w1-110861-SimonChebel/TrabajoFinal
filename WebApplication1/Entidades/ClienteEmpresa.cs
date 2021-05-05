using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class ClienteEmpresa : Cliente
    {
        public string razonSocial { get; set; } = string.Empty;
        public string cuit { get; set; } = string.Empty;
        public TipoEmpresa tipoEmpresa { get; set; } = new TipoEmpresa();
        public ClienteEmpresa() : base()
        { 

        }

    }
}