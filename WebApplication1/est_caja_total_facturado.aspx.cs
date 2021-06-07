using Easy_Stock.Entidades;
using Easy_Stock.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Easy_Stock
{
    public partial class est_caja_total_facturado : System.Web.UI.Page
    {
        protected List<Barra> barrasMes = new List<Barra>();
        protected List<Barra> barrasDias = new List<Barra>();
        protected List<Barra> barrasAnios = new List<Barra>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Reporte oReporte = new ReTotalFacturado();
                oReporte = AdReporte.ObtenerTotalFacturado(oReporte);
                hTotal.InnerText = string.Format("{0} {1}", "Total facturado a la fecha: $", ((ReTotalFacturado)oReporte).CalcularTotalFacturado());
                CargarGraficos();
                Util.CargarComboYears(ref cboAnios);
            }
            else {
                crtFacturacionPorMes.Series["Series"].Points.DataBindXY((List<string>)Session["auxMeses"], (List<Decimal>)Session["totalBarrasPorMes"]);
                crtFacturacionPorDia.Series["Series"].Points.DataBindXY(new string[] { (string)Session["fechaDia"] }, (List<Decimal>)Session["totalBarrasPorDia"]);
                crtFacturacionAnio.Series["Series"].Points.DataBindXY((List<string>)Session["auxMesesAnio"], (List<Decimal>)Session["totalBarrasPorMesAnio"]);

            }
        }

        private void CargarGraficos()
        {
            CargarGraficoMes();
            CargarGraficoPorFecha();
            CargarGraficoAnio();

        }

        private void CargarGraficoMes(int meses=0)
        {
            Reporte oReporte = new ReTotalFacturado();
            ((ReTotalFacturado)oReporte).CambiarQueryPorMes(meses);
            oReporte = AdReporte.ObtenerTotalFacturadoGrafico(oReporte);

            if (oReporte != null)
            {
                int cantidadFacturas = ((ReTotalFacturado)oReporte).facturas.Count;

                ((ReTotalFacturado)oReporte).FiltrarTotalesPorMes(ref barrasMes);

                List<string> auxMeses = new List<string>();
                foreach (var barra in this.barrasMes)
                {
                    auxMeses.Add(barra.DevolverNombreMes());
                }

                crtFacturacionPorMes.Series["Series"].Points.DataBindXY(auxMeses, TotalBarras(barrasMes));
                Session["totalBarrasPorMes"] = TotalBarras(barrasMes);
                Session["auxMeses"] = auxMeses;
            }
            else 
            {
                MostrarMensajeNoEncontrado((int)Tipo.tipoMensajeNoEncontradoGraficos.noEncontradoPorMeses);
            }
            
        }

        private void CargarGraficoAnio(int anio = 0)
        {
            Reporte oReporte = new ReTotalFacturado();
            ((ReTotalFacturado)oReporte).CambiarQueryPorAnio(anio);
            oReporte = AdReporte.ObtenerTotalFacturadoGrafico(oReporte);
            if (oReporte != null)
            {
                divMensajeNoEcontradoAnio.Visible = false;
                ((ReTotalFacturado)oReporte).FiltrarTotalesPorMes(ref barrasAnios, anio);

                List<string> auxMesesAnios = new List<string>();
                foreach (var barra in this.barrasAnios)
                {
                    auxMesesAnios.Add(barra.DevolverNombreMes());
                }
                Session["totalBarrasPorMesAnio"] = TotalBarras(barrasAnios);
                Session["auxMesesAnio"] = auxMesesAnios;

                crtFacturacionAnio.Series["Series"].Points.DataBindXY(auxMesesAnios, (List<Decimal>)Session["totalBarrasPorMesAnio"]);
            }
            else {
                MostrarMensajeNoEncontrado((int)Tipo.tipoMensajeNoEncontradoGraficos.noEncontradorPorAnios);
            }
    
        }
        private void CargarGraficoPorFecha(DateTime fecha =default)
        {
            Reporte oReporte = new ReTotalFacturado();
            ((ReTotalFacturado)oReporte).CambiarQueryPorDia();

            oReporte=  AdReporte.ObtenerTotalFacturadoGrafico(oReporte);
            if (oReporte != null)
            {
                ((ReTotalFacturado)oReporte).FiltrarTotalPorDia(ref barrasDias);

                crtFacturacionPorDia.Series["Series"].Points.DataBindXY(new string[] { barrasDias.First().fecha.ToShortDateString() }, TotalBarras(barrasDias));

                Session["totalBarrasPorDia"] = TotalBarras(barrasDias);
                Session["fechaDia"] = barrasDias.First().fecha.ToShortDateString();
            }
            else
            {
                MostrarMensajeNoEncontrado((int)Tipo.tipoMensajeNoEncontradoGraficos.noEncontradoPorFecha);
            }

        
        }

        private List<Decimal> TotalBarras(List<Barra>lstBarras)
        {
            List<Decimal> lst = new List<decimal>();
            foreach (var item in lstBarras)
            {
                lst.Add(item.total);
            }
            return lst;
        }

        protected void txtFechaDias_TextChanged(object sender, EventArgs e)
        {
            DateTime fecha = Convert.ToDateTime(txtFechaDias.Text);
            Reporte oReporte = new ReTotalFacturado();
            ((ReTotalFacturado)oReporte).CambiarQueryPorDia(fecha);
            oReporte = AdReporte.ObtenerTotalFacturadoGrafico(oReporte);

            if (oReporte != null)
            {
                divMensajeNoEncontradoFecha.Visible = false;
                ((ReTotalFacturado)oReporte).FiltrarTotalPorDia(ref barrasDias, fecha);
                crtFacturacionPorDia.Series["Series"].Points.DataBindXY(new string[] { barrasDias.First().fecha.ToShortDateString() }, TotalBarras(barrasDias));
            }
            else 
            {
                MostrarMensajeNoEncontrado((int)Tipo.tipoMensajeNoEncontradoGraficos.noEncontradoPorFecha);
            }

        }

        protected void cboMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cantidadMesesAnteriores =Convert.ToInt32( ((DropDownList)sender).SelectedValue);
            CargarGraficoMes(cantidadMesesAnteriores);
        }

        protected void cboAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            int anio = Convert.ToInt32(((DropDownList)sender).SelectedValue);
            CargarGraficoAnio(anio);
        }

        private void MostrarMensajeNoEncontrado(int tipoMensajeAmostrar)
        {
            switch (tipoMensajeAmostrar)
            {
                case (int)Tipo.tipoMensajeNoEncontradoGraficos.noEncontradoPorFecha:
                    divMensajeNoEncontradoFecha.Visible = true;
                    break;
                case (int)Tipo.tipoMensajeNoEncontradoGraficos.noEncontradoPorMeses:
                    divNoEncontradoMes.Visible = true;
                    break;
                case (int)Tipo.tipoMensajeNoEncontradoGraficos.noEncontradorPorAnios:
                    divMensajeNoEcontradoAnio.Visible = true;
                    break;
                default:
                    break;
            }
        }
    }
}