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
    public partial class proveedores : Page
    {
        protected Usuario oUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.oUsuario = Session["usuario"] != null ? (Usuario)Session["usuario"] : null;
            if (oUsuario.tipoUsuario.idTipoUsuario != 1) grvProveedores.Columns[9].Visible = false;
            if (!IsPostBack)
            {
                divMensaje.Visible = false;
                if (Request.QueryString["edit"] != null)
                {
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertSuccesDismissable;
                    hMensaje.InnerText = "Los cambios se guardaron correctamente";
                }
                if (Request.QueryString["delete"] != null)
                {
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertSuccesDismissable;
                    hMensaje.InnerText = "Proveedor eliminado correctamente";
                }
                if (oUsuario != null &&oUsuario.tipoUsuario.idTipoUsuario!=1)
                {
                    //grvProveedores.Columns[8].Visible = false;//div de acciones
                }
                List<Proveedor> lstProveedores = AdProveedor.obtenerProveedores();
                if (lstProveedores != null && lstProveedores.Count > 0)
                {
                    grvProveedores.DataSource = lstProveedores;
                    grvProveedores.DataBind();
                }
            }
        }

        protected void grvProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idProveedor = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName.Equals("editar"))
            {
                Response.Redirect("editar_proveedor.aspx?id=" + idProveedor.ToString() + "&accion=" + e.CommandName);
            }
            if (e.CommandName.Equals("editar"))
            {
                if (AdProveedor.eliminarProveedor(idProveedor))
                {
                    Response.Redirect("proveedores.aspx?delete=true");
                }
                else
                {
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertDangerDismissable;
                    hMensaje.InnerText = "Hubo un error al eliminar el proveedor. Intente nuevamente";
                    return;
                }
            }
        }

        protected void btnBuscarProveedores_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscarProveedor.Text;
            if (string.IsNullOrEmpty(nombre)) return;
            grvProveedores.DataSource = null;
            grvProveedores.DataBind();
            List<Proveedor> lstProveedores=  AdProveedor.obtenerProveedores(nombre);
            if (lstProveedores != null)
            {
                divMensaje.Visible = true;
                divMensaje.Attributes["class"] = Bootstrap.alertInfoDismissable;
                hMensaje.InnerText = "Resultados encontrados con " + nombre;
                grvProveedores.DataSource = lstProveedores;
                grvProveedores.DataBind();
            }
            else
            {
                divMensaje.Visible = true;
                divMensaje.Attributes["class"] = Bootstrap.alertWarningDismissable;
                hMensaje.InnerText = "No se encontraron resultados.";
                grvProveedores.DataSource = null;
                grvProveedores.DataBind();
            }
        }
    }
}