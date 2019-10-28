using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FreeSmokyMarket.Data.Entities;
using FreeSmokyMarket.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FreeSmokyMarket.EF.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public void CreateOrder(Order order)
        {
            using (var context = new FreeSmokyMarketContext())
            {
                context.Orders.Add(order);
            }
        }

        public void DeleteOrder(Order order)
        {
            using (var context = new FreeSmokyMarketContext())
            {
                context.Orders.Remove(order);
            }
        }

        public List<Order> GetAllOrders()
        {
            using (var context = new FreeSmokyMarketContext())
            {
                return context.Orders.ToList();
            }
        }

        public Order GetOrder(int id)
        {
            using (var context = new FreeSmokyMarketContext())
            {
                return context.Orders.FirstOrDefault(o => o.OrderId == id);
            }
        }

        public Basket GetBasket(int orderId)
        {
            using (var context = new FreeSmokyMarketContext())
            {
                return context.Orders.Include(b => b.Basket).FirstOrDefault(o => o.OrderId == orderId)?.Basket;
            }
        }

        public void CreateBasket(Basket basket)
        {
            using (var context = new FreeSmokyMarketContext())
            {
                context.Baskets.Add(basket);
            }
        }

        public void DeleteBasket(Basket basket)
        {
            using (var context = new FreeSmokyMarketContext())
            {
                context.Baskets.Remove(basket);
            }
        }

        public void UpdateBasket(Basket basket)
        {
            using (var context = new FreeSmokyMarketContext())
            {
                context.Baskets.Update(basket);
            }
        }
    }
}