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
    public partial class usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divMensaje.Visible = false;
                if (!string.IsNullOrEmpty(Request.QueryString["edit"]))
                {
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertSuccesDismissable;
                    hMensaje.InnerText = "Cambios guardados correctamente";
                }               
                grvUsuarios.DataSource = AdUsuario.ObtenerUsuarios();
                grvUsuarios.DataBind();
                grvUsuarios.Columns[0].Visible = true;
                
            }
        }

        protected void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            divMensaje.Visible = false;
            string nombre = txtBuscarUsuario.Text;
            if (string.IsNullOrEmpty(nombre)) return;
            else
            {
                grvUsuarios.DataSource = null;
                grvUsuarios.DataBind();
                List<Usuario> lstUsuarios = AdUsuario.ObtenerUsuarios("","",0, nombre);
                if (lstUsuarios != null && lstUsuarios.Count > 0)
                {
                    grvUsuarios.DataSource = lstUsuarios;
                    grvUsuarios.DataBind();
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertInfoDismissable;
                    hMensaje.InnerText = string.Format("{0} {1}", "Resultados encontrados con:", nombre);
                }
                else 
                {
                    grvUsuarios.DataSource = lstUsuarios;
                    grvUsuarios.DataBind();
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertWarningDismissable;
                    hMensaje.InnerText = "No se econtraron resultados";
                }
            }
        }

        protected void grvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string comando = e.CommandName;
            string id = e.CommandArgument.ToString();
            if (comando.Equals("editar"))
            {
                Response.Redirect("editar_usuario?id="+id+"&accion="+comando);
            }
            if (comando.Equals("eliminar"))
            {
                if (AdUsuario.eliminarUsuario(Convert.ToInt32(id)))
                {
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertSuccesDismissable;
                    hMensaje.InnerText = "Usuario borrado correctamente";
                }
                else 
                {
                    divMensaje.Visible = true;
                    divMensaje.Attributes["class"] = Bootstrap.alertDanger;
                    hMensaje.InnerText = "Hubo un problema al eliminar el usuario. Intente nuevamente";
                    return;
                }
            }
        }
    }
}