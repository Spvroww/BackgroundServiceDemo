using BackgroundServiceDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundServiceDemo.Services
{
    public class InBuiltSmtpEmailService : IEmailService
    {
        private readonly EmailServerConfiguration _emailServerConfiguration;

        public InBuiltSmtpEmailService(EmailServerConfiguration emailServerConfiguration)
        {
            _emailServerConfiguration = emailServerConfiguration;
        }

        public async Task SendAsync(Email email)
        {
            using SmtpClient smtpClient = new SmtpClient()
            {
                Host = _emailServerConfiguration.Host,
                Port = _emailServerConfiguration.Port,
                Credentials = new NetworkCredential()
                {
                    UserName = _emailServerConfiguration.Username,
                    Password = _emailServerConfiguration.Password
                },
                EnableSsl = true
            };
           
            MailAddress senderAddress = new(_emailServerConfiguration.From);
            MailAddress recieverAddress = new(email.Reciever.Value);

            MailMessage message = new(senderAddress, recieverAddress)
            {
                Subject = email.Subject,
                Body = email.Body
            };

            smtpClient.SendAsync(message,"Done");

            smtpClient.Dispose();
        }
    }
}
