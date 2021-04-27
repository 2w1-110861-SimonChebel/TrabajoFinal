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
    public partial class productos : System.Web.UI.Page
    {
        protected List<Producto> lstProductos = new List<Producto>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lstProductos = AdProducto.obtenerProductos();
                grvProductos.DataSource = lstProductos;
                grvProductos.DataBind();
            }
        }

        protected void btnEditarProducto_Click(object sender, EventArgs e) 
        {
            Response.Redirect("/editar_producto.aspx?idProducto=3", false);
        }
    }
}