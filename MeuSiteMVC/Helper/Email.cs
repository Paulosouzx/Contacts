using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;

namespace MeuSiteMVC.Helper
{
    public class Email : IEmail
    {
        private readonly IConfiguration _configuration;

        public Email(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Send(string email, string subject, string message)
        {
            try
            {
                string username = _configuration.GetValue<string>("SMTP:UserName");
                string name = _configuration.GetValue<string>("SMTP:Name");
                string host = _configuration.GetValue<string>("SMTP:Host");
                string password = _configuration.GetValue<string>("SMTP:Password");
                int porta = _configuration.GetValue<int>("SMTP:Porta");

                MailMessage mailMessage = new MailMessage() 
                {
                    From = new MailAddress(username, name)
                };

                mailMessage.To.Add(email);
                mailMessage.Subject = subject;
                mailMessage.Body = message;
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(host, porta))
                {
                    smtp.Credentials = new NetworkCredential(username, password);
                    smtp.EnableSsl = true;

                    smtp.Send(mailMessage);
                    return true;
                };

            }
            catch (Exception e)
            {
                return false;
            }
            
        }
    }
}
