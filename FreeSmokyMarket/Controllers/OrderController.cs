using System.IO;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using FreeSmokyMarket.Infrastructure.Logging;
using FreeSmokyMarket.Data.Repositories;
using FreeSmokyMarket.Data.Entities;
using FreeSmokyMarket.EF;
using FreeSmokyMarket.Infrastructure.Interfaces;

namespace FreeSmokyMarket.Controllers
{
    public class OrderController : Controller
    {
        FreeSmokyMarketContext _ctx;
        ILogger _logger;
        IOrderRepository _orderRepository;
        ISenderFactory _senderFactory;
        IConfiguration _configuration;

        public OrderController(FreeSmokyMarketContext ctx,
                               ILoggerFactory loggerFactory,
                               IOrderRepository orderRepository,
                               IConfiguration configuration,
                               ISenderFactory senderFactory)
        {
            _ctx = ctx;
            _orderRepository = orderRepository;
            _senderFactory = senderFactory;
            _configuration = configuration;

            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "HomeControllerLogs.txt"));
            _logger = loggerFactory.CreateLogger("FileLogger");
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

            _logger.LogInformation(message);

            _senderFactory.CreateSender("mail")?.SendMessageAsync(message);
            _senderFactory.CreateSender("telegram")?.SendMessageAsync(message);

            return "Спасибо, " + order.FirstName + " " + order.LastName + ", за покупку!";
        }
    }
}