using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FreeSmokyMarket.Infrastructure.ISender
{
    public interface IMailSender
    {
        Task SendEmailAsync(string sender,
                            string password,
                            string recipient,
                            string message,
                            string senderName = "FreeSmokyMarketMailSender",
                            string subject = "Placed order");
    }
}
