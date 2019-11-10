using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Net;
using FreeSmokyMarket.Infrastructure.ISender;

namespace FreeSmokyMarket.Infrastructure.MailSender
{
    public class SmtpMailSender : IMailSender
    {
        public async Task SendEmailAsync(string sender, 
                                                 string password, 
                                                 string recipient, 
                                                 string message,
                                                 string senderName,
                                                 string subject)
        {
            MailAddress from = new MailAddress(sender, "FreeSmokyMarketMailSender");
            MailAddress to = new MailAddress(recipient);
            MailMessage m = new MailMessage(from, to);
            m.Subject = subject;
            m.Body = message;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(sender, password);
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
        }
    }
}
