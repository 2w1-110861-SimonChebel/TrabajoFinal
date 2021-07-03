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

            if (AdUsuario.VerificarEmailExiste(email))
            {
                SmtpClient smtp = new SmtpClient();
                Envio.EnviarMail(smtp, "easystockar@gmail.com", email, "stock123*", HtmlBody.AsuntoClientePorVentaCliente,  HtmlBody.BodyConfirmacionClave.Replace("@id",email));
            }
            else 
            {
                divMensajeEmail.Visible = true;
            }
      


        }
    }
}