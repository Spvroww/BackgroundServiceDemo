using BackgroundServiceDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundServiceDemo.Services
{
    public class OrderService : IOrderService
    {
        public void PlaceOrder(Email email)
        {
            Console.WriteLine("Your order has been placed Successfully. Check your email");
            email.Body = "Order Placed: Thank you for patronizing us";
            FakeQueue.Add(email);
        }
    }
}
