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

        }

        protected void BtnIngresar_Click(Object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string clave = txtClave.Text;
            Usuario oUsuario = AdUsuario.ObtenerUsuarios(email, clave).FirstOrDefault();
            if (oUsuario != null)
            {
                Response.Redirect("/home.aspx?usuario=" + oUsuario.nombre+ "." + oUsuario.apellido, false);
            }
            else
            {
                divAlertaDatosIncorrectos.Style["display"] = "inherit";
            }

        }
    }
}