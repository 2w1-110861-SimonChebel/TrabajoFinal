using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class ReVentaPorTipoCliente : Reporte
    {
        public int cantidadVentasPersonas = 0;
        public int cantidadVentasEmpresas = 0;

        public ReVentaPorTipoCliente() : base()
        {
            
        }

        public string[] CalcularPorcentajePorTipo()
        {
            string[] resultado = new string[4];
            resultado[0] = ((cantidadVentasPersonas) * 100 / (cantidadVentasEmpresas+cantidadVentasPersonas)).ToString();
            resultado[1] = ((cantidadVentasEmpresas) * 100 / (cantidadVentasEmpresas + cantidadVentasPersonas)).ToString();
            resultado[2] = cantidadVentasPersonas.ToString();
            resultado[3] = cantidadVentasEmpresas.ToString();
            return resultado;
        }
    }

}