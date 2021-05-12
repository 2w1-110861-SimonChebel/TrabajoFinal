using Easy_Stock.Entidades;
using System;

namespace Easy_Stock
{
    public partial class MyMaster : System.Web.UI.MasterPage
    {
        protected Usuario oUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
                Response.Redirect("principal.aspx");
            oUsuario = (Usuario)Session["usuario"];
            lblUsuario.Text = string.Format("{0} {1}",oUsuario.nombre,oUsuario.apellido);
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Response.Redirect("principal.aspx?session=out");
        }
    }
}