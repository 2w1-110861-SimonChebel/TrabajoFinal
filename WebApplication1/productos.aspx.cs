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
            
        }
        protected void btnEliminarProducto_Click(object sender, EventArgs e)
        {
         
        }
        protected void grvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idProducto = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("editar"))
            {              
                Response.Redirect("editar_producto.aspx?id=" + idProducto.ToString() +"&accion="+e.CommandName);
            }
            else if(e.CommandName.Equals("eliminar"))
            {
                try
                {
                    AdProducto.eliminarProductoPorId(idProducto);                   
                    divMensaje.InnerText = "Producto eliminado correctamente";
                    divMensaje.Style["class"] = "alert alert-success";
                    Response.Redirect("productos.aspx");
                }
                catch (Exception ex)
                {                  
                    divMensaje.InnerText = "Hubo un error al eliminar el producto";
                    divMensaje.Style["class"] = "alert alert-danger";
                    Response.Redirect("productos.aspx");
                    throw ex;
                }
                
               
              
            }
                           
        }
    }
}