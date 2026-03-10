using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace _10_01_26_SMTP_HW
{
    internal class EmailService
    {
        private readonly string host;
        private readonly int port;
        private readonly string email;
        private readonly string password;
        private readonly SmtpClient smtpClient;

        public EmailService(string email, string password)
        {
            host = "smtp.gmail.com";
            port = 587;
            this.email = email;
            this.password = password;

            smtpClient = new SmtpClient(host, port);
            smtpClient.Credentials = new NetworkCredential(email, password);
            smtpClient.EnableSsl = true;
        }

        public void SendFileText(string toEmail, string subject, string filePath, List<string> attachments)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Головного файла \"{toEmail}\" не існує");
                return;
            }
            bool isHtml = false;
            if (Path.GetExtension(filePath).ToLower().Equals(".html"))
            {
                isHtml = true;
            }
            string body = File.ReadAllText(filePath);



            MailMessage message = new MailMessage();
            message.From = new MailAddress(this.email);
            message.To.Add(new MailAddress(toEmail));
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = isHtml;
            foreach (var att in attachments)
            {
                if (File.Exists(att))
                {
                    message.Attachments.Add(new Attachment(att));
                }
                else
                {
                    Console.WriteLine($"Файла для прикріплення \"{att}\" не існує");
                }
            }
            Console.WriteLine("Надсилання...");
            smtpClient.Send(message);
            Console.WriteLine("Надіслано успішно!");
        }


    }
}
