using System;
using System.Collections.Generic;
using System.Text;

namespace AdvanceCSharp.EventHandling
{
    public class MailingService
    {
        public void SendMail(string title)
        {
            Console.WriteLine("Sending mail for video.. " + title);
        }
    }
}
