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
                return context.Baskets.Where(b => b.Id == id).FirstOrDefault();
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
    }
}
