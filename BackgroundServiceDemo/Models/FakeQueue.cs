using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BackgroundServiceDemo.Models
{
    public static class FakeQueue
    {

        private static readonly Queue<Email> _emails = new();

        public static Queue<Email> Emails => _emails;

        public static void Add(Email email)
        {
            _emails.Enqueue(email);         
        }
        
        public static void Dequeue()
        {
            _emails.Dequeue();
        }
    }
}
