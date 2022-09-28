using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using static System.Net.WebRequestMethods;

namespace SMTP.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com");

            string pw = "cdtaeljjakwyrgfj";
            string to = "fernando.restituto@georgebrown.ca";
            string from = "concof.zp@gmail.com";
            string file = "function.txt";

            MailMessage message = new MailMessage(from, to);

            Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
            message.Attachments.Add(data);

            message.Subject = "Hi Fernando! Do you copy? I hosted SMTP!";
            message.Body = @"Yes, I did it!!! SMTP WORKS! EVERYTHING WORKS AWESOME! Function.txt is attached! GIVE ME A+ !";


            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(from, pw);
            client.EnableSsl = true;
            
            try
            {
                client.Send(message);
                Console.WriteLine("MessageSent");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                    ex.ToString());
            }
        }
    }
}