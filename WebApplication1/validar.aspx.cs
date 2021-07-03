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
    public partial class validar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                
                string id = Request.QueryString["id"];
                txtEmail.Text = id;
                Session["idReset"] = id;
            }
            else {
                Response.Redirect("principal.aspx");
            }
           
        }

        protected void btnReestablecer_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string clave = txtClave1.Text;

            if (AdGeneral.ReestablecerClave(email, clave))
            {
                Session["idReset"] = null;
                Response.Redirect("principal.aspx?reset=true");
            }
            else
            {
                divMensaje.Attributes["visibility"] = "inherit";
                divMensaje.Attributes["class"] = Bootstrap.alertDangerDismissable;
                hMensaje.InnerText = "Hubo un error al reestablecer la clave. Intente nuevamente";
            }


        }
    }
}