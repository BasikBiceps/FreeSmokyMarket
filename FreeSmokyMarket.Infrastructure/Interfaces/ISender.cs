using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FreeSmokyMarket.Infrastructure.Interfaces
{
    public interface ISender
    {
        Task SendMessageAsync(string message);
    }
}
