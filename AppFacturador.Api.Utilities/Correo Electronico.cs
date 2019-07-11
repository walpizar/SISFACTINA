using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace AppFacturador.Api.Utilities
{
    public static class Correo_Electronico
    {

        public static bool EnviarCorreo(string correo)
        {

            MailMessage email = new MailMessage();
            SmtpClient smtp = new SmtpClient("smtp.live.com",25);
            
            try
            {
            email.To.Add(new MailAddress( correo));
            email.From = new MailAddress("correopruebafac@hotmail.com");
                email.Subject = "Correo de prueba";
                email.SubjectEncoding = Encoding.UTF8;
            email.Body = "Correo enviado por el Sistema de Facturacion Electronica. INA 2019 " +
                    " Enviado el dia (" + DateTime.Now.ToString("dd/MM/yyyy hh:mm") + ")";
                email.BodyEncoding = Encoding.UTF8;
            email.IsBodyHtml = false;
            email.Priority = MailPriority.Normal;

            
           
            smtp.EnableSsl = true;
            
            smtp.Credentials = new NetworkCredential("correopruebafac@hotmail.com", "12345fac");

                bool output = false;

                smtp.Send(email);
                email.Dispose();
                output = true;
                return true;  

            }
            catch (Exception EX)
            {

                throw;
            }

        }
    }
}
