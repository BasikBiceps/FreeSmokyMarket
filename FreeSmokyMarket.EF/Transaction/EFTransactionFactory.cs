using System;
using System.Collections.Generic;
using System.Text;

using FreeSmokyMarket.Infrastructure.Interfaces;

namespace FreeSmokyMarket.EF.Transaction
{
    public class EFTransactionFactory : ITransactionFactory
    {
        public ITransaction StartTransaction()
        {
           return new EFTransaction(new FreeSmokyMarketContext().Database.BeginTransaction());
        }
    }
}