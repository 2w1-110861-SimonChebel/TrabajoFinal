using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class TipoUsuario
    {
        public int idTipoUsuario { get; set; } = 0;

        public string tipoUsuario { get; set; } = string.Empty;

        public TipoUsuario() { 
        }
    }
}