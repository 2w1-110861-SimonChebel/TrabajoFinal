using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class ClientePersona : Cliente
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dni { get; set; }
        public DateTime fechaNacimiento { get; set; } = (default);
        public Sexo sexo { get; set; } = new Sexo();
        public ClientePersona() : base()
        {
        }
    }
}