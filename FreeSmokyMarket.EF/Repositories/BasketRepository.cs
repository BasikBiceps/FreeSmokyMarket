using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

using FreeSmokyMarket.Data.Repositories;
using FreeSmokyMarket.Data.Entities.Aggregates;

namespace FreeSmokyMarket.EF.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        public Basket GetBasketByOrderId(int orderId)
        {
            using (var context = new FreeSmokyMarketContext())
            {
                return GetBasketByOwnId(context.Orders.Where(o => o.Id == orderId).FirstOrDefault().BasketId);
            }
        }

        public Basket GetBasketByOwnId(int id)
        {
            using (var context = new FreeSmokyMarketContext())
            {
                return context.Baskets.Include(b => b.PurchasesItems).Where(b => b.Id == id).FirstOrDefault();
            }
        }

        public void CreateBasket(Basket basket)
        {
            using (var context = new FreeSmokyMarketContext())
            {
                context.Baskets.Add(basket);
                context.SaveChanges();
            }
        }

        public void DeleteBasket(Basket basket)
        {
            using (var context = new FreeSmokyMarketContext())
            {
                context.Baskets.Remove(basket);
                context.SaveChanges();
            }
        }

        public void UpdateBasket(Basket basket)
        {
            using (var context = new FreeSmokyMarketContext())
            {
                context.Baskets.Update(basket);
                context.SaveChanges();
            }
        }

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
