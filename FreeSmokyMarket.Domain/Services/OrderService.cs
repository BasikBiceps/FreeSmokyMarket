using System;

using FreeSmokyMarket.Data.Entities;
using FreeSmokyMarket.Data.Repositories;
using FreeSmokyMarket.Data.Entities.Aggregates;
using FreeSmokyMarket.Domain.Interfaces;
using FreeSmokyMarket.Infrastructure.Interfaces;

namespace FreeSmokyMarket.Domain.Services
{
    public class OrderService : IOrderService
    {
        private IBasketRepository _basketRepository;
        private IOrderRepository _orderRepository;
        private ITransactionFactory _transactionFactory;

        public OrderService(IBasketRepository basketRepository,
                            IOrderRepository orderRepository,
                            ITransactionFactory transactionFactory)
        {
            _basketRepository = basketRepository;
            _orderRepository = orderRepository;
            _transactionFactory = transactionFactory;
        }

        public void MakeOrder(Basket basket, Order order)
        {
            if (basket == null || order == null)
            {
                return;
            }

            using (var transaction = _transactionFactory.StartTransaction())
            {
                basket.IsActive = false;
                _basketRepository.UpdateBasket(basket);

                order.BasketId = basket.Id;
                order.OrderDate = DateTime.Now;
                _orderRepository.CreateOrder(order);

                transaction.Commit();
            }
        }
    }
}