using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using FreeSmokyMarket.Data.Repositories;
using FreeSmokyMarket.Data.Entities.Aggregates;
using FreeSmokyMarket.Domain.Interfaces;

namespace FreeSmokyMarket.Controllers
{
    public class BasketController : Controller
    {
        IReservationService _reservationService;
        IBasketRepository _basketRepository;

        public BasketController(IReservationService reservationService,
                                IBasketRepository basketRepository)
        {
            _reservationService = reservationService;
            _basketRepository = basketRepository;
        }

        public IActionResult ShowBasket()
        {
            var selectedProducts = _reservationService.ShowReservedProducts(HttpContext.Session.Id);
            var basket = _basketRepository.GetActiveBasketBySessionId(HttpContext.Session.Id);
            List<PurchasesItem> purchasesItems;

            if (basket == null || !basket.IsActive)
            {
                purchasesItems = new List<PurchasesItem>();
            }
            else
            {
                purchasesItems = basket.PurchasesItems;
            }

            ViewData["PurchasesItems"] = purchasesItems;

            return View(selectedProducts);
        }

        public IActionResult DeleteFromBasket(int id)
        {
            _reservationService.UnreserveProduct(HttpContext.Session.Id, id);

            return Redirect("/Basket/ShowBasket");
        }
    }
}