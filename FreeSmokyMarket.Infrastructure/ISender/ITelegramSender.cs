using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FreeSmokyMarket.Infrastructure.ISender
{
    public interface ITelegramSender
    {
        Task SendMessageAsync(string channelToken, string channelId, string message);
    }
}