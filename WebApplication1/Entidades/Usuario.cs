using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string clave { get; set; }
        public string email { get; set; }
        public TipoUsuario tipoUsuario { get; set; } = null;

        public Usuario()
        {
            idUsuario = 0;
            nombre = string.Empty;
            apellido = string.Empty;
            clave = string.Empty;
            email = string.Empty;
            tipoUsuario = new TipoUsuario();
        }

    }
}