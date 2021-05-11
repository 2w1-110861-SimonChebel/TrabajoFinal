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
                
            }
        }

        protected void btnBuscarUsuario_Click(object sender, EventArgs e)
        {

        }

        protected void grvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string comando = e.CommandName;
            string id = e.CommandArgument.ToString();
            if (comando.Equals("editar"))
            {
                Response.Redirect("editar_usuario?id="+id+"&accion="+comando);
            }
        }
    }
}