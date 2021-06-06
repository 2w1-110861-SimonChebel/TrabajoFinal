using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class Barra
    {
        public DateTime fecha { get; set; } = default;
        public decimal total { get; set; } = 0;
        public Barra()
        {
            
        }

        public string DevolverNombreMes()
        {
            switch (this.fecha.Month)
            {
                case 1:
                    return Fecha.enero;
              
                case 2:
                    return Fecha.febrero;
                case 3:
                    return Fecha.marzo;
                case 4:
                    return Fecha.abril;
                case 5:
                    return Fecha.mayo;
                case 6:
                    return Fecha.junio;
                case 7:
                    return Fecha.julio;
                case 8:
                    return Fecha.agosto;
                case 9:
                    return Fecha.septiembre;
                case 10:
                    return Fecha.octubre;
                case 11:
                    return Fecha.noviembre;
                case 12:
                    return Fecha.diciembre;
                default:
                    return string.Empty;
            }
        }
    }
}