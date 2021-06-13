using Easy_Stock.AccesoDatos;
using Easy_Stock.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Easy_Stock
{
    public partial class est_ventas : Page
    {
        protected List<Categoria> categorias;
        protected List<Producto> productos;
        protected ReVenta oReVentaCat;
        protected ReVenta oReVentaProd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (cboCategorias.SelectedValue == "0") divMensajeNoEncontrado.Visible = false;

                oReVentaCat = AdReporte.ObtenerTotalPorCategoria();
                Session["oReVentaCat"] = oReVentaCat;

                oReVentaProd = AdReporte.ObtenerTotalPorProduto();
                Session["oReVentaProd"] = oReVentaProd;

                categorias = AdCategoria.obtenerCategorias();
                Session["catRanking"] = categorias;

                CargarCombo();
            }
            else {
                if (cboCategorias.SelectedValue == "0") divMensajeNoEncontrado.Visible = false;
                if (Session["oReVentaCat"]!= null) oReVentaCat = (ReVenta)Session["oReVentaCat"];
                if(Session["catRanking"]!= null) categorias = (List<Categoria>)Session["catRanking"];
                if (Session["oReVentaProd"] != null) oReVentaProd = (ReVenta)Session["oReVentaProd"];
                if (Session["TotalesCategorias"] != null && Session["ValorTotalCategoria"] != null)
                    crtVentasCategoria.Series["Series"].Points.DataBindXY((List<string>)Session["TotalesCategorias"],(List<decimal>)Session["ValorTotalCategoria"]);
            }
        }

        protected void cboCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReVenta  oReVenta = AdReporte.ObtenerTotalPorCategoria(Convert.ToInt32(((DropDownList)sender).SelectedValue));
            if (oReVenta != null)
            {
                divMensajeNoEncontrado.Visible = false;
                Session["totalPorCategoria"] = null;
                List<string> lstTotalesCategorias = new List<string> { oReVenta.totalesCategoriasxFactura.First().categoria.nombre };
                List<decimal> lstValorTotal = new List<decimal> { oReVenta.CalcularTotalPorCategoria() };
                crtVentasCategoria.Series["Series"].Points.DataBindXY(lstTotalesCategorias, lstValorTotal);

                crtVentasCategoria.ToolTip = lstValorTotal.First().ToString();

                Session["TotalesCategorias"] = lstTotalesCategorias;
                Session["ValorTotalCategoria"] = lstValorTotal;

            }
            else {
                Session["TotalesCategorias"] = null;
                Session["ValorTotalCategoria"] = null;
                divMensajeNoEncontrado.Visible = true;
            }
        }

        private void CargarCombo()
        {
            cboCategorias.DataSource = null;

            foreach (var item in categorias)
            {
                cboCategorias.Items.Add(
                    new ListItem { 
                        Value = item.idCategoria.ToString(),
                        Text = item.nombre
                    }
                );
            }
        }
    }
}