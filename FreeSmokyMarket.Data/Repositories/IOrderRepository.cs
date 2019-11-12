using System;
using System.Collections.Generic;
using System.Text;

using FreeSmokyMarket.Data.Entities;

namespace FreeSmokyMarket.Data.Repositories
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        void DeleteOrder(Order order);
        List<Order> GetAllOrders();
        Order GetOrder(int orderId);
    }
}