using System;
using System.Collections.Generic;
using System.Text;

using FreeSmokyMarket.Data.Entities;

namespace FreeSmokyMarket.Data.Repositories
{
    interface IOrderRepository
    {
        void CreateOrder(Order order);
        void DeleteOrder(Order order);
        List<Order> GetAllOrders();
        Order GetOrder(int id);
        Basket GetBasket(int id);
        void CreateBasket(Basket basket);
        void DeleteBasket(Basket basket);
        void AddConcreteProductInBasket(int concreteProductId);
    }
}
