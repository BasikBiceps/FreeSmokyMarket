using System;
using System.Collections.Generic;
using System.Text;

namespace FreeSmokyMarket.Infrastructure.Interfaces
{
    public interface ITransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
