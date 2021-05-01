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
    public partial class reponer_producto : System.Web.UI.Page
    {
        protected List<ProductoReponer> lstProductos = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            hMensaje.InnerText = "";
            lstProductos = AdProducto.obtenerProductosReponer(txtBuscar.Text);
            if (lstProductos == null)
            {
                hMensaje.InnerText = "No se encontraron resultados";
            }
            else 
            {
                grvProductos.DataSource = lstProductos;
                grvProducto.DataBind();
            }
  
        }
    }
}