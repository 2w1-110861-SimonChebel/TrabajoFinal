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
        public string nombre { get; set; } = string.Empty;
        public string apellido { get; set; } = string.Empty;
        public string dni { get; set; } = string.Empty;
        public TipoEmpresa tipoEmpresa {get;set;} = new TipoEmpresa();
        public string razonSocial { get; set; } = string.Empty;
        public string telefono { get; set; } = string.Empty;
        string email { get; set; } = string.Empty;
        string direccion { get; set; } = string.Empty;
        public string barrio { get; set; } = string.Empty;
        public Localidad localidad { get; set; } = new Localidad();
        public Provincia provincia { get; set; } = new Provincia();
        public string codigoPostal { get; set; } = string.Empty;
        DateTime fechaNacimiento { get; set; } = (default);
        public Sexo sexo { get; set; } = new Sexo();
        public DeudaCliente deuda { get; set; } = new DeudaCliente();


    }
}