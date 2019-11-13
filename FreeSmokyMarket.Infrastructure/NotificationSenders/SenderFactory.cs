using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.Configuration;

using FreeSmokyMarket.Infrastructure.Interfaces;
using FreeSmokyMarket.Infrastructure.NotificationSenders;

namespace FreeSmokyMarket.Infrastructure.NotificationSenders
{
    public class SenderFactory : ISenderFactory
    {
        IConfiguration _configuration;
        public string MailSenderName { get; set; } = "mail";
        public string TelegramSenderName { get; set; } = "telegram";

        public SenderFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ISender CreateSender(string senderName)
        {
            if (senderName.Equals(MailSenderName))
            {
                return new SmtpMailSender(_configuration["Mails:Sender"], _configuration["Mails:SenderPassword"], _configuration["Mails:Recipient"]);
            }

            if (senderName.Equals(TelegramSenderName))
            {
                return new TelegramSender(_configuration["Telegram:ChannelToken"], _configuration["Telegram:ChannelId"]);
            }

            return null;
        }
    }
}
