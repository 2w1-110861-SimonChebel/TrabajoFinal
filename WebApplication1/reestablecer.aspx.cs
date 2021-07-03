using Easy_Stock.AccesoDatos;
using Easy_Stock.Entidades;
using System;
using System.Net.Mail;
using System.Security.Cryptography;


namespace Easy_Stock
{
    public partial class reestablecer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReestablecer_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            divMensaje.Visible = false;
            hMensaje.InnerText = "";
            if (AdUsuario.VerificarEmailExiste(email))
            {
                SmtpClient smtp = new SmtpClient();
                Envio.EnviarMail(smtp, "easystockar@gmail.com", email, "stock123*", HtmlBody.AsuntoReestablecerClave,  HtmlBody.BodyConfirmacionClave.Replace("@id",email));
                divMensaje.Visible = true;
                hMensaje.InnerText = string.Format("{0} {1}", "Se envió un email a " ,email);
                txtEmail.Text = string.Empty;
            }
            else 
            {
                divMensaje.Visible = false;
                divMensajeEmail.Visible = true;
            }
      


        }
    }
}