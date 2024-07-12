using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundServiceDemo.Exceptions
{
    public class EmailServerConfigurationNotFoundException : Exception
    {
        public EmailServerConfigurationNotFoundException() : base(message: "Email server settings not found")
        {
        }
    }
}
