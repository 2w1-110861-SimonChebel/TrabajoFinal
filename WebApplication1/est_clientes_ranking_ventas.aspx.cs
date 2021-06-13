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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lstFacturas = AdReporte.ObtenerRankingClientes();
            }
        }
    }
}