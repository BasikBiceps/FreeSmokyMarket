using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using FreeSmokyMarket.Data.Repositories;
using FreeSmokyMarket.Data.Entities;
using FreeSmokyMarket.EF;
using FreeSmokyMarket.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace FreeSmokyMarket.Controllers
{
    public class OrderController : Controller
    {
        readonly ISenderFactory _senderFactory;
        private readonly ILogger<HomeController> _logger;

        public OrderController(FreeSmokyMarketContext ctx,
                               IOrderRepository orderRepository,
                               IConfiguration configuration,
                               ISenderFactory senderFactory,
                               ILogger<HomeController> logger)
        {
            _senderFactory = senderFactory;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Buy()
        {
            return View();
        }

        [HttpPost]
        public string Buy(Order order)
        {
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

            _logger.LogDebug(message);
            _senderFactory.CreateSender("mail")?.SendMessageAsync(message);
            _senderFactory.CreateSender("telegram")?.SendMessageAsync(message);

            return "Спасибо, " + order.FirstName + " " + order.LastName + ", за покупку!";
        }
    }
}