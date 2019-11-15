using System;
using System.Collections.Generic;
using System.Text;
using FreeSmokyMarket.Data.Entities;

namespace FreeSmokyMarket.Data.Repositories
{
    public interface IPurchasesItemRepository
    {
        PurchasesItem GetPurchasesItem(int itemId);
        void CreatePurchasesItem(PurchasesItem item);
        void DeletePurchasesItem(PurchasesItem item);
        void UpdatePurchasesItem(PurchasesItem item);
    }
}
