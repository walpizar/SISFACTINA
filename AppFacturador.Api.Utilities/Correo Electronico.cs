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
            email.Subject = "Asunto: Correo de prueba:  Enviado el dia (" + DateTime.Now.ToString("dd/MM/yyyy hh:mm") + ")";
                email.SubjectEncoding = Encoding.UTF8;
            email.Body = "Contenido de cuerpo";
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
