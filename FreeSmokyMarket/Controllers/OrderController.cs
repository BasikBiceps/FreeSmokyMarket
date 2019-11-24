using Microsoft.AspNetCore.Mvc;

using FreeSmokyMarket.Data.Repositories;
using FreeSmokyMarket.Data.Entities;
using FreeSmokyMarket.Infrastructure.Interfaces;
using FreeSmokyMarket.Domain.Interfaces;

namespace FreeSmokyMarket.Controllers
{
    public class OrderController : Controller
    {
        ISenderFactory _senderFactory;
        IBasketRepository _basketRepository;
        IOrderService _orderService;

        public OrderController(ISenderFactory senderFactory,
                               IBasketRepository basketRepository,
                               IOrderService orderService)
        {
            _senderFactory = senderFactory;
            _basketRepository = basketRepository;
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Buy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Buy(Order order)
        {
            if (!ModelState.IsValid)
                return View(new ViewModels.Order());

            var message = "Orders fields: \nFirstName: "
                    + order.FirstName
                    + "\nLastName: "
                    + order.LastName
                    + "\nPhoneNumber:"
                    + order.PhoneNumber
                    + "\nAddress: "
                    + order.Address
                    + "\nOrderId: "
                    + order.Id;

            _orderService.MakeOrder(_basketRepository.GetActiveBasketBySessionId(HttpContext.Session.Id), order);

            _senderFactory.CreateSender("mail")?.SendMessageAsync(message);
            _senderFactory.CreateSender("telegram")?.SendMessageAsync(message);

            return Content("Спасибо, " + order.FirstName + " " + order.LastName + ", за покупку!");
        }
    }
}