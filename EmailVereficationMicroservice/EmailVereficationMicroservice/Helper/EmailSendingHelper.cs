using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailVereficationMicroservice.Helper
{
    public static class EmailSendingHelper
    {
   
        public static async Task SendEmailAsync(string toEmail ,int vereficationCode)
        {
            string fromEmail = "wazowskijmike@gmail.com";
            string password = "cmos amuu dtys ynxp";

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("FitnessApp", fromEmail));
            message.To.Add(new MailboxAddress("Recipient", toEmail));
            message.Subject = "Email Verefication";
            message.Body = new TextPart("plain")
            {
                Text = "Hello :) It's your verefication Code "+ vereficationCode
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                await client.ConnectAsync("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                await client.AuthenticateAsync(fromEmail, password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }

        }


    }

}

