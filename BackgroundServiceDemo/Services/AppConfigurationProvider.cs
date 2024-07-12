using BackgroundServiceDemo.Exceptions;
using BackgroundServiceDemo.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundServiceDemo.Services
{
    public static class AppConfigurationProvider
    {
        private static IConfigurationRoot _configuration;

        public static IConfigurationRoot Configuration { get {  
                //Set file to read configurations
                    var builder = new ConfigurationBuilder();
                    builder.SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true);
                
                    var configuration = builder.Build();

                //Implement thread safety
                Interlocked.CompareExchange<IConfigurationRoot>(ref _configuration, configuration, null );
                    
                
                return _configuration;
            } }

        public static EmailServerConfiguration GetEmailConfiguration()
        {
            EmailServerConfiguration emailServerConfiguration = Configuration.GetSection("EmailServerSettings")?
                .Get<EmailServerConfiguration>() ??
                throw new EmailServerConfigurationNotFoundException();
            return emailServerConfiguration;
        }
    }
}
