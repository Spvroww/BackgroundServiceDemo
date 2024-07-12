using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundServiceDemo.Models
{
    public record EmailServerConfiguration(string From, string Host, int Port, string Username, string Password);
}
