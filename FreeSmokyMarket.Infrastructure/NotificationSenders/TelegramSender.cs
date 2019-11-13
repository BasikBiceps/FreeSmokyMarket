using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FreeSmokyMarket.Infrastructure.Interfaces;
using Telegram.Bot;

namespace FreeSmokyMarket.Infrastructure.NotificationSenders
{
    public class TelegramSender : ISender
    {
        private string _channelToken;
        private string _channelId;

        public TelegramSender(string channelToken, string channelId)
        {
            _channelToken = channelToken;
            _channelId = channelId;
        }

        public async Task SendMessageAsync(string message)
        {
            // "893249251:AAHBBaHjMkBVyDcjz0ELv60SJIcIN37VnFo"
            // "-335012834"
            var bot = new TelegramBotClient(_channelToken);
            await bot.SendTextMessageAsync(_channelId, message);
        }
    }
}