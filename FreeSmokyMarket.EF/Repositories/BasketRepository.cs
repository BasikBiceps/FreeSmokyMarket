using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

using FreeSmokyMarket.Data.Repositories;
using FreeSmokyMarket.Data.Entities;

namespace FreeSmokyMarket.EF.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        public Basket GetBasket(int orderId)
        {
            using (var context = new FreeSmokyMarketContext())
            {
                return context.Baskets.Where(b => b.OrderId == orderId).FirstOrDefault();
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

        public int GetLastId()
        {
            using (var context = new FreeSmokyMarketContext())
            {
                return context.Baskets.Count();
            }
        }
    }
}
