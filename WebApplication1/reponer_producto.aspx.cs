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
            lstProductos = AdProducto.ObtenerProductosReponer(txtBuscar.Text);
            if (lstProductos == null)
            {
                hMensaje.InnerText = "No se encontraron resultados";
            }
            else 
            {
                grvProducto.DataSource = lstProductos;
                grvProducto.DataBind();
            }
  
        }

        protected void grvProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grvProducto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            divMensaje.Visible = false;
            TextBox txt = ((TextBox)grvProducto.Rows[0].FindControl("txtNuevaCantidad"));
            int cantidad =string.IsNullOrEmpty(txt.Text) ? 0 :  Convert.ToInt32(txt.Text);

            if (cantidad < 1)
            {
                divMensaje.Visible = true;
                divMensaje.Attributes["class"] = Bootstrap.alertWarning;
                hMensaje.InnerText = "La cantidad debe ser un número entero mayor a cero (0)";
                return;
            }
            else 
            {
                string[] args = e.CommandArgument.ToString().Split(',');
                string codigo = args[1];
                int id = Convert.ToInt32(args[0]);
                if (AdProducto.ReponerProductos(id, codigo, cantidad))
                {
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertSuccesDismissable;
                    hMensaje.InnerText = "Se repuso el producto correctamente.";
                    return;

                }
                else 
                {
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertDangerDismissable;
                    hMensaje.InnerText = "Hubo en error al reponer el producto. Intente nuevamente.";
                }
            }

            
        }
    }
}