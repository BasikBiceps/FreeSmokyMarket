using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using FreeSmokyMarket.Data.Entities;
using FreeSmokyMarket.Data.Repositories;

namespace FreeSmokyMarket.EF.Repositories
{
    public class PurchasesItemRepository : IPurchasesItemRepository
    {
        public PurchasesItem GetPurchasesItem(int itemId)
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                return ctx.PurchasesItems.Where(pi => pi.Id == itemId).FirstOrDefault();
            }
        }

        public void CreatePurchasesItem(PurchasesItem item)
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                ctx.PurchasesItems.Add(item);
                ctx.SaveChanges();
            }
        }

        public void DeletePurchasesItem(PurchasesItem item)
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                ctx.PurchasesItems.Remove(item);
                ctx.SaveChanges();
            }
        }

        public void UpdatePurchasesItem(PurchasesItem item)
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                ctx.PurchasesItems.Update(item);
                ctx.SaveChanges();
            }
        }
    }
}
