// See https://aka.ms/new-console-template for more information
using BackgroundServiceDemo.Services;
using BackgroundServiceDemo.Models;
using System.Diagnostics;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;


Console.WriteLine("Application Started");

//Get Email Configuration
var emailServerConfiguration = AppConfigurationProvider.GetEmailConfiguration();

//Add Hosted Service
var host = new HostBuilder()
    .ConfigureServices(services => services.AddHostedService<EmailProcessingBackgroundService>()).Build();
await host.StartAsync();

try
{
    while(true)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        //Instantiate email
        Email email = new()
        {
            Subject = "Test From Background Service",
        };

        //Get Info from User
        do
        {
            Console.WriteLine("Type in your email address to place your order");
            email.Reciever = new EmailAddress(Console.ReadLine());

            if (!email.Reciever.IsValid)
            {
                Console.WriteLine("Invalid email address");
            }
        }
        while(!email.Reciever.IsValid);

        // Instantiate order service and place order
        IOrderService orderService = new OrderService();
        orderService.PlaceOrder(email);

        stopwatch.Stop();
        Console.WriteLine($"Logic completed in {stopwatch.Elapsed}");
    }
}
catch (Exception ex)
{
    Console.WriteLine("An exception occured in your application");
    Console.WriteLine("Message: {0}", ex.Message);
    
}





