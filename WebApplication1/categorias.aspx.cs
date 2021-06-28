using Easy_Stock.AccesoDatos;
using Easy_Stock.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace Easy_Stock
{
    public partial class categorias : System.Web.UI.Page
    {
        protected List<Categoria> lstCategorias;
        protected bool eliminar;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lstCategorias = AdCategoria.ObtenerCategorias();
                if (!string.IsNullOrEmpty(Request.QueryString["edit"]))
                {
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertSuccesDismissable;
                    hMensaje.InnerText = "Datos guardados correctamente";
                }

                if (!string.IsNullOrEmpty(Request.QueryString["delete"]))
                {
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertSuccesDismissable;
                    hMensaje.InnerText = "Categoria eliminada";
                }

                if (lstCategorias != null && lstCategorias.Count() > 0)
                {
                    grvCategorias.DataSource = lstCategorias;
                    grvCategorias.DataBind();
                }
                else
                {
                    divMensaje.Visible = true;
                }
            }
        }

        protected void grvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grvCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (eliminar)
            {
                if (AdCategoria.EliminarCategoria(id))
                {
                    Response.Redirect("categorias.aspx?delete=true");
                }
                else
                {
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertDangerDismissable;
                    hMensaje.InnerText = "Hubo un error. Intente nuevamente";
                }
            }
            else
            {
                Response.Redirect("editar_cat.aspx?i=" + id);
            }
           

            //else
            //{
            //    divMensaje.Visible = true;
            //    divMensaje.Attributes["class"] = Bootstrap.alertDangerDismissable;
            //    divMensaje.InnerText = "Hubo un problema. Intentar nuevamente";
            //    return;
            //}

        }

        protected void btnEditarCat_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminarCat_Click(object sender, EventArgs e)
        {
            eliminar = true;
        }

        protected void btnBuscarCat_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscarCat.Text;
            if (string.IsNullOrEmpty(nombre)) return;
            else 
            {
                List<Categoria> lst = AdCategoria.ObtenerCategorias(nombre);
                if (lst != null)
                {
                    grvCategorias.DataSource = lst;
                    grvCategorias.DataBind();
                    divMensaje.Visible = false;
                }
                else 
                {
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertWarningDismissable;
                    divMensaje.InnerText = "No se encontraron resultados";
                    grvCategorias.DataSource = null;
                    grvCategorias.DataBind();
                }
            }
        }

        protected void btnRecargar_Click(object sender, EventArgs e)
        {
            List<Categoria> lst = AdCategoria.ObtenerCategorias();
            if (lst != null)
            {
                divMensaje.Visible = false;
                grvCategorias.DataSource = lst;
                grvCategorias.DataBind();
            }
            else 
            {
                grvCategorias.DataSource = null;
            }
        }

        protected void btnNuevaCat_Click(object sender, EventArgs e)
        {
            Response.Redirect("editar_cat.aspx");
        }
    }
}