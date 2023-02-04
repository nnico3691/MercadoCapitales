﻿using MailKit.Net.Smtp;
using MercadoCapitales.API.Clientes.Modelo;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Threading.Tasks;


namespace MercadoCapitales.API.Clientes.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailSenderService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task SenderEmailAsync(MailRequest request)
        {
            try 
            {
                var message = new MimeMessage();

                message.From.Add(new MailboxAddress(_smtpSettings.SenderName,_smtpSettings.SenderEmail));
                message.To.Add(new MailboxAddress("", request.Email));
                message.Subject = request.Subject;
                message.Body =  new TextPart("html") { Text = request.Body };

                /*
                 .NETMAILER
                 CONTRASEÑA afrokeirfhgiljhf
                 */

                using (var client = new SmtpClient()) 
                {
                    await client.ConnectAsync(_smtpSettings.Server);
                    await client.AuthenticateAsync(_smtpSettings.UserName, _smtpSettings.Password);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                
            } 
            catch(Exception) 
            {
                throw;
            }
        }
    }
}
