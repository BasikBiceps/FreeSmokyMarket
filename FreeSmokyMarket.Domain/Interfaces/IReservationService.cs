using System.Collections.Generic;

using FreeSmokyMarket.Data.Entities;

namespace FreeSmokyMarket.Domain.Interfaces
{
    public interface IReservationService
    {
        void ReserveProduct(string sessionId, int productId);
        List<Product> ShowReservedProducts(string sessionId);
        void UnreserveProduct(string sessionId, int productId);
    }
}