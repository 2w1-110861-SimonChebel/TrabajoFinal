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
    public partial class est_clientes_ranking_ventas : System.Web.UI.Page
    {
        protected List<Factura> lstFacturas = null;
        protected ReVentaPorTipoCliente oVentas = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lstFacturas = AdReporte.ObtenerRankingClientes();
                oVentas = AdTransaccion.ObtenerPorcentajeVentaPorTipoCliente();
                string[] aux = oVentas.CalcularPorcentajePorTipo();
                crtTipoClientes.Series["Series"].Points.DataBindXY(new List<string> {string.Format("{0} {1} {2} {3}", "Ventas a personas","(",aux[0],"%)"), string.Format("{0} {1} {2} {3}", "Ventas a empresas", "(", aux[1], "%)") },new List<int> {oVentas.cantidadVentasPersonas,oVentas.cantidadVentasEmpresas });
                hCantVentasPersonas.InnerText = string.Format("{0}{1}", hCantVentasPersonas.InnerText, aux[2].ToString());
                hCantVentasEmpresas.InnerText = string.Format("{0}{1}", hCantVentasEmpresas.InnerText, aux[3].ToString());
            }
        }
    }
}