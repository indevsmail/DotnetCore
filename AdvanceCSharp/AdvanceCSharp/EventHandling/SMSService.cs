using System;
using System.Collections.Generic;
using System.Text;

namespace AdvanceCSharp.EventHandling
{
    public class SMSService
    {
        public void SendSMS(string title)
        {
            Console.WriteLine("Sending SMS... " + title);
        }
    }
}
