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
        protected Producto oProducto = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            oProducto = AdProducto.obtenerProductoPorNombre(txtBuscar.Text);
            if (oProducto == null)
            {
                hMensaje.InnerText = string.Format("{0} {1}", "No se encontró el producto", txtBuscar.Text);
            }
  
        }
    }
}