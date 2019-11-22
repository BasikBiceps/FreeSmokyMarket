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
                context.SaveChanges();
            }
        }

        public void DeleteOrder(Order order)
        {
            using (var context = new FreeSmokyMarketContext())
            {
                context.Orders.Remove(order);
                context.SaveChanges();
            }
        }

        public List<Order> GetAllOrders()
        {
            using (var context = new FreeSmokyMarketContext())
            {
                return context.Orders.ToList();
            }
        }

        public Order GetOrder(int orderId)
        {
            using (var context = new FreeSmokyMarketContext())
            {
                return context.Orders.Where(o => o.Id == orderId).FirstOrDefault();
            }
        }
    }
}