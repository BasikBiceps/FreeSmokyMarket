using System.IO;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using FreeSmokyMarket.Logging;
using FreeSmokyMarket.Data.Repositories;
using FreeSmokyMarket.EF;

namespace FreeSmokyMarket.Controllers
{
    public class BrandsController : Controller
    {
        FreeSmokyMarketContext _ctx;
        ILogger _logger;
        IBrandRepository _brandRepository;

        public BrandsController(FreeSmokyMarketContext ctx,
                                ILoggerFactory loggerFactory,
                                IBrandRepository brandRepository)
        {
            _ctx = ctx;
            _brandRepository = brandRepository;

            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "HomeControllerLogs.txt"));
            _logger = loggerFactory.CreateLogger("FileLogger");
        }
        public IActionResult ShowBrands(int id)
        {
            _logger.LogInformation("ShowBrands method in Home controller: ID == {0}", id);

            return View(_brandRepository.GetAllBrands(id));
        }
    }
}