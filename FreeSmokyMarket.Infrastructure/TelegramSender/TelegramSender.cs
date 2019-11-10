using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FreeSmokyMarket.Infrastructure.ISender;
using Telegram.Bot;

namespace FreeSmokyMarket.Infrastructure.TelegramSender
{
    public class TelegramSender : ITelegramSender
    {
        public async Task SendMessageAsync(string channelToken, string channelId, string message)
        {
            // "893249251:AAHBBaHjMkBVyDcjz0ELv60SJIcIN37VnFo"
            // "-335012834"
            var bot = new TelegramBotClient(channelToken);
            await bot.SendTextMessageAsync(channelId, message);
        }
    }
}