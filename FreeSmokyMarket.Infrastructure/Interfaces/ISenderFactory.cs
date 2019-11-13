using System;
using System.Collections.Generic;
using System.Text;

namespace FreeSmokyMarket.Infrastructure.Interfaces
{
    public interface ISenderFactory
    {
        ISender CreateSender(string senderName);
    }
}
