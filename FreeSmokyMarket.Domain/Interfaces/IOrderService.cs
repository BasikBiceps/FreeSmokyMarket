using FreeSmokyMarket.Data.Entities;
using FreeSmokyMarket.Data.Entities.Aggregates;

namespace FreeSmokyMarket.Domain.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(Basket basket, Order order);
    }
}