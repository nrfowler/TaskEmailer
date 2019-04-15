using System;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace TaskEmailer
{
    class Program
    {
        static void Main(string[] args)
        {

            var lines = File.ReadLines(args[2]);
            foreach(var line in lines)
                SendMail(args[0],args[1],line, line);
        }

        private static void SendMail(string username, string password, string sub, string body)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(username,password);

            MailMessage mm = new MailMessage("nrfowler@gmail.com", "nrfowler@gmail.com", sub, body);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);
        }
    }
}
