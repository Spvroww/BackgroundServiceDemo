using BackgroundServiceDemo.Models;
using Microsoft.Extensions.Hosting;

namespace BackgroundServiceDemo.Services
{
    public class EmailProcessingBackgroundService : BackgroundService
    {
        private readonly IEmailService mailKitEmailService;

        public EmailProcessingBackgroundService()
        {
            mailKitEmailService =  new MailKitSmtpEmailService(AppConfigurationProvider.GetEmailConfiguration());

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await ProccessEmailsAsync();
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }


        private async Task ProccessEmailsAsync()
        {
            await Task.Run(async () =>{
                if (FakeQueue.Emails.Count() > 0)
                {                                  
                    foreach(var email in FakeQueue.Emails)
                    {
                        await Console.Out.WriteLineAsync($"Proccessing: {email.ToString()}\n");
                        await mailKitEmailService.SendAsync(email);
                        FakeQueue.Dequeue();
                       
                    }

                }
            });

        }
    }
}
