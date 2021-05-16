using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class Empresa
    {
        public int idEmpresa { get; set; } = 0;
        public string nombre { get; set; } = string.Empty;
        public string cuit { get; set; } = string.Empty;
        public string direccion { get; set; } = string.Empty;
        public DateTime inicioActividades { get; set; } = DateTime.Today;

        public Empresa()
        {
            
        }
        
    }
}