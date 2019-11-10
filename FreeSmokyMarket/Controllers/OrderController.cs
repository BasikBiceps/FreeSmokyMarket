using System.IO;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using FreeSmokyMarket.Logging;
using FreeSmokyMarket.Data.Repositories;
using FreeSmokyMarket.Data.Entities;
using FreeSmokyMarket.EF;
using FreeSmokyMarket.Infrastructure.ISender;

namespace FreeSmokyMarket.Controllers
{
    public class OrderController : Controller
    {
        FreeSmokyMarketContext _ctx;
        ILogger _logger;
        IOrderRepository _orderRepository;
        IMailSender _mailSender;
        IConfiguration _configuration;


        public OrderController(FreeSmokyMarketContext ctx,
                               ILoggerFactory loggerFactory,
                               IOrderRepository orderRepository,
                               IConfiguration configuration,
                               IMailSender mailSender)
        {
            _ctx = ctx;
            _orderRepository = orderRepository;
            _mailSender = mailSender;
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
            _logger.LogInformation("Orders fields: \nFirstName: {0}\nLastName: {0}\nPhoneNumber: {0}\nAddress: {0}",
                order.FirstName,
                order.LastName,
                order.PhoneNumber,
                order.Address);

            var sender = _configuration["Mails:Sender"];
            var senderPassword = _configuration["Mails:SenderPassword"];
            var recipient = _configuration["Mails:Recipient"];

            _mailSender.SendEmailAsync(sender, senderPassword, recipient, "Orders fields: \nFirstName: "
                + order.FirstName
                + "\nLastName: "
                + order.LastName
                + "\nPhoneNumber:"
                + order.PhoneNumber
                + "\nAddress: "
                + order.Address
                + "\nOrderId: "
                + order.OrderId);

            return "Спасибо, " + order.FirstName + " " + order.LastName + ", за покупку!";
        }
    }
}