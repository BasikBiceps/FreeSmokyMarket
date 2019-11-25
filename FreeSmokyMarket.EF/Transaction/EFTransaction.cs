using System;
using System.Collections.Generic;
using System.Text;

using FreeSmokyMarket.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace FreeSmokyMarket.EF.Transaction
{
    public class EFTransaction : ITransaction
    {
        private IDbContextTransaction _ctx;

        public EFTransaction(IDbContextTransaction ctx)
        {
            _ctx = ctx;
        }

        public void Commit()
        {
            _ctx.Commit();
        }

        public void Rollback()
        {
            _ctx.Rollback();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
