using System;
using System.Collections.Generic;
using System.Text;

using FreeSmokyMarket.Data.Entities.Aggregates;

namespace FreeSmokyMarket.Data.Repositories
{
    public interface IBasketRepository
    {
        Basket GetBasketByOrderId(int orderId);
        Basket GetBasketByOwnId(int id);
        void CreateBasket(Basket basket);
        void DeleteBasket(Basket basket);
        void UpdateBasket(Basket basket);

        PurchasesItem GetPurchasesItem(int itemId);
        void CreatePurchasesItem(PurchasesItem item);
        void DeletePurchasesItem(PurchasesItem item);
        void UpdatePurchasesItem(PurchasesItem item);
    }
}
