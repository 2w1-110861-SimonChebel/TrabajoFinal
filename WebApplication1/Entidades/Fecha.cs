using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public static class Fecha
    {
        public static string[] meses = new string[] {
            "Enero","Febrero","Marzo","Abril","Mayo","Junio","Julio","Agosto","Septiembre",
            "Octubre","Noviembre","Diciembre"
        };

        public enum EMeses { 

            Enero = 1,
            Febrero = 2,
            Marzo = 3,
            Abril = 4,
            Mayo = 5,
            Junio = 6,
            Julio = 7,
            Agosto = 8,
            Septiembre = 9,
            Octubre = 10,
            Noviembre = 11,
            Diciembre = 12
        }

        public static string enero { get; } = "Enero";
        public static string febrero { get; } = "Febrero";
        public static string marzo { get; } = "Marzo";
        public static string abril { get; } = "Abril";
        public static string mayo { get; } = "Mayo";
        public static string junio { get; } = "Junio";
        public static string julio { get; } = "Julio";
        public static string agosto { get; } = "Agosto";
        public static string septiembre { get; } = "Septiembre";
        public static string octubre { get; } = "Octubre";
        public static string noviembre { get; } = "Noviembre";
        public static string diciembre { get; } = "Diciembre";


    }
}