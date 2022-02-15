using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;

namespace Toyota.Helper.Notification
{
    public class Email
    {
        public static string ukrNet_pswd = "s5GkRZ5C0gsROw9e";

        public static async Task SendEmailAsync(string email = "fozzynice@gmail.com", string subject = "Запрос", string message = "test")
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта Toyota", "forzyng@ukr.net"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.ukr.net", 465, true);
                await client.AuthenticateAsync("forzyng@ukr.net", ukrNet_pswd);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }

    }
}
