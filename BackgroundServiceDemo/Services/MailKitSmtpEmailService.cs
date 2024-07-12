using BackgroundServiceDemo.Models;
using MailKit.Net.Smtp;
using MimeKit;

namespace BackgroundServiceDemo.Services
{
    public class MailKitSmtpEmailService : IEmailService
    {
        private readonly EmailServerConfiguration _emailServerConfiguration;

        public MailKitSmtpEmailService(EmailServerConfiguration emailServerConfiguration)
        {
            _emailServerConfiguration = emailServerConfiguration;
        }

        public async Task SendAsync(Email email)
        {
            using var client = new SmtpClient();
            await client.ConnectAsync(host: _emailServerConfiguration.Host, 
                port: _emailServerConfiguration.Port, 
                options: MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_emailServerConfiguration.Username, _emailServerConfiguration.Password);
            await client.SendAsync(CreateEmail(email));
            await client.DisconnectAsync(true);
            client.Dispose();

        }

        private MimeMessage CreateEmail(Email email)
        {
            var message = new MimeMessage()
            {
                Subject = email.Subject,
                Body = new TextPart(MimeKit.Text.TextFormat.Text)
                {
                    Text = email.Body
                }
            };
            message.From.Add(new MailboxAddress("Test", _emailServerConfiguration.From));
            message.To.Add(new MailboxAddress("Reciever", email.Reciever.Value));           
            return message;
            
        }
    }
}
