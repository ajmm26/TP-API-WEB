using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace service
{
    public class emailService
    {
        private MailMessage email;
        private SmtpClient server;

        public emailService()
        {
            server = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("utnprogramacionprueba@gmail.com", "wbid fklt bsaj jijb"),
                EnableSsl = true
            };
        }
        public void armarCorreo(string emailDestino)
        {
            email = new MailMessage();
            email.From = new MailAddress("utnprogramacionprueba@gmail.com");
            email.To.Add(emailDestino);
            email.Subject = "Asunto";
            email.IsBodyHtml = true;
            email.Body = @"<h1>&#10004;</h1>
                           <h1>MUCHAS GRACIAS!</h1>
                           <h2>TU REGISTRO HA SIDO EXITOSO</h2>
                           <hr />
                           <h4>Ya participas del sorteo del producto que elegiste</h4>
                           <h6>Pronto estaremos comunicando los ganadores</h6>
                            ";

        }
        public void enviarMail()
        {
            if (email == null)
                throw new InvalidOperationException("El correo no fue armado correctamente.");

            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
