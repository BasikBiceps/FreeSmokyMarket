using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Net;
using FreeSmokyMarket.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;

namespace FreeSmokyMarket.Infrastructure.NotificationSenders
{
    public class SmtpMailSender : ISender
    {
        private string _sender;
        private string _password;
        private string _recipient;
        private string _senderName;
        private string _subject;

        public SmtpMailSender(string sender,
                              string password,
                              string recipient,
                              string senderName = "FreeSmokyMarket",
                              string subject = "Place ordered")
        {
            _sender = sender;
            _password = password;
            _recipient = recipient;
            _senderName = senderName;
            _subject = subject;
        }

        public async Task SendMessageAsync(string message)
        {
            MailAddress from = new MailAddress(_sender, _senderName);
            MailAddress to = new MailAddress(_recipient);
            MailMessage m = new MailMessage(from, to);
            m.Subject = _subject;
            m.Body = message;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(_sender, _password);
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
        }
    }
}
