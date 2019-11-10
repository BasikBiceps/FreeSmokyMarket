using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Net;

namespace FreeSmokyMarket.Infrastructure.MailSender
{
    static public class MailSender
    {
        public static async Task SendEmailAsync(string sender, 
                                                 string password, 
                                                 string recipient, 
                                                 string message,
                                                 string senderName = "FreeSmokyMarketMailSender",
                                                 string subject = "Placed order")
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
