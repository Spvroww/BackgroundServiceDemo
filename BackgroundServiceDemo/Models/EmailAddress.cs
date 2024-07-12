using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BackgroundServiceDemo.Models
{
    public class EmailAddress
    {
        public EmailAddress(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
        public bool IsValid => Validate(Value);    
        
        private bool Validate(string value)
        {
            Regex regex = new Regex(@"^([a-zA-Z0-9._%-]+)@([a-zA-Z0-9.-]+)\.([a-zA-Z]{2,4})$");
            bool isValid = regex.IsMatch(Value);
            return isValid;
        }
    }
}
