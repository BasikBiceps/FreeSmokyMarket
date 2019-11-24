using System;
using System.Collections.Generic;

using FreeSmokyMarket.Data.Entities;
using FreeSmokyMarket.Data.Entities.Aggregates;
using FreeSmokyMarket.Domain.Interfaces;
using FreeSmokyMarket.Data.Repositories;

namespace FreeSmokyMarket.Domain.Services
{
    public class ReservationService : IReservationService
    {
        private IProductRepository _productRepository;
        private IBasketRepository _basketRepository;

        public static int SessionTimeLimitInMinutes { get; } = 20;

        public ReservationService(IProductRepository productRepository,
                                  IBasketRepository basketRepository)
        {
            _productRepository = productRepository;
            _basketRepository = basketRepository;
        }

        public void ReserveProduct(string sessionId, int productId)
        {
            using (var transaction = new FreeSmokyMarket.EF.FreeSmokyMarketContext().Database.BeginTransaction())
            {
                if (_productRepository.GetProduct(productId).Amount <= 0)
                {
                    transaction.Rollback();
                    return;
                }

                var basket = _basketRepository.GetActiveBasketBySessionId(sessionId);

                if (basket == null)
                {
                    var purchasesItems = new List<PurchasesItem>();
                    var newItem = new PurchasesItem();
                    newItem.Amount = 1;
                    newItem.ProductId = productId;
                    purchasesItems.Add(newItem);

                    basket = new Basket();
                    basket.BasketCreation = DateTime.Now;
                    basket.PurchasesItems = purchasesItems;
                    basket.SessionId = sessionId;

                    var product = _productRepository.GetProduct(productId);
                    product.Amount--;

                    _productRepository.UpdateProduct(product);
                    _basketRepository.CreateBasket(basket);
                }
                else {
                    var purchasesItem = basket.PurchasesItems.Find(p => { return p.ProductId == productId; });

                    if (purchasesItem == null)
                    {
                        var newItem = new PurchasesItem();
                        newItem.Amount = 1;
                        newItem.ProductId = productId;

                        basket.PurchasesItems.Add(newItem);
                        _basketRepository.UpdateBasket(basket);
                    }
                    else
                    {
                        purchasesItem.Amount++;
                        _basketRepository.UpdateBasket(basket);
                    }

                    var product = _productRepository.GetProduct(productId);
                    product.Amount--;

                    _productRepository.UpdateProduct(product);
                }

                transaction.Commit();
            }
        }

        public List<Product> ShowReservedProducts(string sessionId)
        {
            UpdateReservation();

            var basket = _basketRepository.GetActiveBasketBySessionId(sessionId);

            if (basket == null)
            {
                return new List<Product>();
            }

            var selectedProducts = new List<Product>();

            foreach (var el in basket.PurchasesItems)
            {
                selectedProducts.Add(_productRepository.GetProduct(el.ProductId));
            }

            return selectedProducts;
        }

        public void UnreserveProduct(string sessionId, int productId)
        {
            using (var transaction = new FreeSmokyMarket.EF.FreeSmokyMarketContext().Database.BeginTransaction())
            {
                var basket = _basketRepository.GetActiveBasketBySessionId(sessionId);

                if (basket == null)
                {
                    return;
                }

                var item = basket.PurchasesItems.Find(p => { return p.ProductId == productId; });

                if (item == null)
                {
                    return;
                }

                item.Amount--;

                if (item.Amount <= 0)
                {
                    _basketRepository.DeletePurchasesItem(item);
                    basket.PurchasesItems.Remove(item);
                }

                _basketRepository.UpdateBasket(basket);

                var product = _productRepository.GetProduct(productId);
                product.Amount++;

                _productRepository.UpdateProduct(product);

                transaction.Commit();
            }
        }

        public void UpdateReservation()
        {
            using (var transaction = new FreeSmokyMarket.EF.FreeSmokyMarketContext().Database.BeginTransaction())
            {
                var baskets = _basketRepository.GetAllBaskets();

                foreach (var basket in baskets)
                {
                    if (basket.IsActive && DateTime.Now.Subtract(basket.BasketCreation).TotalMinutes >= SessionTimeLimitInMinutes)
                    {
                        foreach (var item in basket.PurchasesItems)
                        {
                            var product = _productRepository.GetProduct(item.ProductId);
                            product.Amount += item.Amount;
                            _productRepository.UpdateProduct(product);
                        }

                        basket.IsActive = false;
                        _basketRepository.UpdateBasket(basket);
                    }
                }

                transaction.Commit();
            }
        }
    }
}