using BackgroundServiceDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundServiceDemo.Services
{
    public interface IEmailService
    {
        public Task SendAsync(Email email);
    }
}
