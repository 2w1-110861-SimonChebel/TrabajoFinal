using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace Easy_Stock.Entidades
{
    public static class Envio
    {

        public static bool EnviarMail(SmtpClient smtp, string fromEmail, string toEmail ,string clave, string asunto, Transaccion oTran=null, Cliente oCliente=null, Usuario oUsuario=null, string body="")
        {
            smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(fromEmail, clave);
            smtp.EnableSsl = true;
           
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(fromEmail, "Easy Stock");
            mail.To.Add(new MailAddress(toEmail));
            mail.Subject = asunto;
            mail.IsBodyHtml = true;
            mail.Body = body;
            smtp.Send(mail);

            return false;
        }

        public static bool EnviarMail(SmtpClient smtp, string fromEmail, string toEmail, string clave, string asunto, Transaccion oTran = null,Proveedor proveedor = null, Usuario oUsuario = null, string body = "")
        {
            smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(fromEmail, clave);
            smtp.EnableSsl = true;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(fromEmail, "Easy Stock");
            mail.To.Add(new MailAddress(toEmail));
            mail.Subject = asunto;
            mail.IsBodyHtml = true;
            mail.Body = body;
            smtp.Send(mail);

            return false;
        }

        public static bool EnviarMail(SmtpClient smtp, string fromEmail, string toEmail, string clave, string asunto,  string body = "")
        {
            smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(fromEmail, clave);
            smtp.EnableSsl = true;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(fromEmail, "Easy Stock");
            mail.To.Add(new MailAddress(toEmail));
            mail.Subject = asunto;
            mail.IsBodyHtml = true;
            mail.Body = body;
            smtp.Send(mail);

            return false;
        }
    }
}