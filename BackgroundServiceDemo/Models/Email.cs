using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BackgroundServiceDemo.Models
{
    public class Email
    {       
        public EmailAddress Reciever { get;  set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
