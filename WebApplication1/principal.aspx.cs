using Easy_Stock.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

using AdUsuario = Easy_Stock.AccesoDatos.AdUsuario;

namespace Easy_Stock
{
    public partial class principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divAlertaDatosIncorrectos.Visible = false;
                if (Request.QueryString["session"] != null && Request.QueryString["session"].Equals("out"))
                {
                    divAlertaDatosIncorrectos.Visible = true;
                    divAlertaDatosIncorrectos.Attributes["class"] = Bootstrap.alertSuccesDismissable;
                    hMensaje.InnerText = "La sesión se cerró correctamente";
                }
            }
        }

        protected void BtnIngresar_Click(Object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string clave = txtClave.Text;
            Usuario oUsuario = AdUsuario.ObtenerUsuarios(email, clave).FirstOrDefault();
            if (oUsuario != null)
            {
                Session["usuario"] = (Usuario)oUsuario;
                Response.Redirect("/home.aspx?usuario=" + oUsuario.nombre+ "." + oUsuario.apellido, false);
            }
            else
            {
                divAlertaDatosIncorrectos.Visible = true;
                hMensaje.InnerText = "El usuario y/o contraseña son incorrectos";
            }

        }
    }
}