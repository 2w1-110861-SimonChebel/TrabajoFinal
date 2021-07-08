using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace Easy_Stock.Entidades
{
    public class ReTotalFacturado : Reporte
    {
        public List<Factura> facturas { get; set; } = null;
        public decimal totalTodasFacturas { get; set; } = 0;

        public ReTotalFacturado() : base()
        {
            facturas = new List<Factura>();
            query = new Query();
            query.comando = " select f.nroFactura, SUM(f.total)FROM Facturas f GROUP BY f.nroFactura";
        }

        public decimal CalcularTotalFacturado()
        {
            decimal total = 0;
            foreach (var item in facturas)
            {
                total += item.total;
            }
            return total;
        }
        public void CambiarQueryPorMes(int cantidadMeses = 2)
        {
            StringBuilder sb = null;
            if (cantidadMeses == 1) //para traer solo el mes actual
            {
                sb = new StringBuilder(" select f.nroFactura, SUM(f.total),f.fecha ");
                sb.Append("  FROM Facturas f WHERE month(f.FECHA) =  MONTH(GETDATE()) AND YEAR (f.FECHA) = YEAR (GETDATE())  ");
                sb.Append(" GROUP BY f.nroFactura,f.fecha ORDER BY f.fecha ASC ");
            }
            else {
                sb = new StringBuilder(" select f.nroFactura, SUM(f.total),f.fecha ");
                sb.Append("  FROM Facturas f WHERE f.fecha >= DATEADD(MM,- @meses,GETDATE()) and f.fecha <= GETDATE()  ");
                sb.Append(" GROUP BY f.nroFactura,f.fecha ORDER BY f.fecha ASC ");
                this.query.parametros = new SqlParameter[] {
                new SqlParameter("@meses",cantidadMeses ==0? 2 : cantidadMeses)
                };

            }
          
            this.query.comando = sb.ToString();
        }

        public void CambiarQueryPorDia(DateTime fecha = default)
        {
            StringBuilder sb;
            if (fecha == default)
            {

                sb = new StringBuilder(" select f.nroFactura, SUM(f.total),f.fecha FROM Facturas f ");
                sb.Append("  where DAY(f.FECHA) = day(GETDATE()) AND MONTH(f.FECHA) = MONTH(GETDATE()) AND YEAR (f.FECHA) = YEAR (GETDATE()) ");
                sb.Append(" GROUP BY f.nroFactura,f.fecha ORDER BY f.fecha ASC ");

            }
            else
            {
                sb = new StringBuilder(" select f.nroFactura, SUM(f.total),f.fecha FROM Facturas f");
                sb.Append(" where DAY(f.FECHA) = day(@fecha) AND MONTH(f.FECHA) = MONTH(@fecha) AND YEAR (f.FECHA) = YEAR (@fecha)  ");
                sb.Append(" GROUP BY f.nroFactura,f.fecha ORDER BY f.fecha ASC ");

                this.query.parametros = new SqlParameter[] {
                new SqlParameter("@fecha",fecha)
                };
            }


            this.query.comando = sb.ToString();
        }

        public void CambiarQueryPorAnio(int anio=0)
        {
            StringBuilder sb;

            if (anio > 0 && !anio.Equals(DateTime.Today.Year))
            {
                sb = new StringBuilder(" select f.nroFactura, SUM(f.total),f.fecha FROM Facturas f");
                sb.Append(" where  YEAR (f.FECHA) = @anio  ");
                sb.Append(" GROUP BY f.nroFactura,f.fecha ORDER BY f.fecha ASC ");
                this.query.parametros = new SqlParameter[] {
                    new SqlParameter("@anio", anio)
                };
            }
            else
            {

                sb = new StringBuilder(" select f.nroFactura, SUM(f.total),f.fecha FROM Facturas f");
                sb.Append(" where  YEAR (f.FECHA) = YEAR (GETDATE())  ");
                sb.Append(" GROUP BY f.nroFactura,f.fecha ORDER BY f.fecha ASC ");
            }

            this.query.comando = sb.ToString();
        }

        public void FiltrarTotalesPorMes(ref List<Barra> barras, int anio=0)
        {
            decimal totalPorMes = 0;
            int mesIterando = 0;
            int cont = 0;
            DateTime fechaAnterior = default;
            foreach (var item in this.facturas)
            {

                if (cont > 0) { fechaAnterior = this.facturas[cont - 1].fecha; }
                cont++;
                //if(item.fecha.Month != fechaAnterior.Month) mesIterando = item.fecha.Month; ;
                if (mesIterando == 0) mesIterando = item.fecha.Month;
                if (mesIterando != 0 && item.fecha.Month == mesIterando && cont < this.facturas.Count)
                {
                    totalPorMes += item.total;                 
                }
                if (cont < facturas.Count)
                {
                    if (facturas[cont].fecha.Month != mesIterando)
                    {
                        //pregunta si es el ultimo dato y suma el valor a totalPorMes
                        if (cont == this.facturas.Count) totalPorMes += item.total;
                        if (item.fecha.Month != mesIterando) barras.Add(new Barra { fecha = fechaAnterior, total = totalPorMes });
                        else barras.Add(new Barra { fecha = item.fecha, total = totalPorMes });
                        totalPorMes = 0;
                        mesIterando = 0;
                        fechaAnterior = default;
                    }
                    else continue;
                 
                }
                else { totalPorMes += item.total; barras.Add(new Barra { fecha = item.fecha, total = totalPorMes });}
               
            }
            
            //if (anio>0) barras = barras.Where(b => b.fecha.Year == anio).ToList();

            //lstFacturas.OrderBy(f => f.fecha.Month == DateTime.Today.Month);
        }

        public void FiltrarTotalPorDia(ref List<Barra> barras, DateTime fecha = default)
        {
            decimal totalPorDia = 0;
            int cont = 0;
            Barra oBarra = new Barra();
            foreach (var item in this.facturas)
            {
                cont++;
                if (item.fecha.ToShortDateString() == DateTime.Today.ToShortDateString() || item.fecha.ToShortDateString() == fecha.ToShortDateString())
                {
                    oBarra.fecha = item.fecha;
                    totalPorDia += item.total;
                }
            }
            oBarra.total = totalPorDia;
            barras.Add(oBarra);

        }
    }
}