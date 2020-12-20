using ASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private CurrenciesManager currenciesManager;
        private DataDownloader dataDownloader;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            this.currenciesManager = new CurrenciesManager();
            this.dataDownloader = new DataDownloader(currenciesManager);
        }

        public IActionResult Index()
        {
            var result = new HomeViewModel();
            result.PrimaryCurrencies = this.currenciesManager.GetPossibleMainCurrencies();

            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        [IgnoreAntiforgeryToken]
        public JsonResult GetSecondaryCurrencies(string mainCurrency)
        {
            var res = new SecondaryCurrenciesResult()
            {
                Currencies = this.currenciesManager.GetPossibleTransfers(mainCurrency)
            };

            return Json(res);
        }

        [HttpGet]
        [IgnoreAntiforgeryToken]
        public JsonResult GetConversionRate(string conversion, int chartType)
        {
            var currencies = conversion.Split('/');
            var data = this.dataDownloader.DownloadData(currencies[0], currencies[1], (Data.Constants.ChartTypes)chartType);
            var res = new Prices()
            {
                AllPrices = data.CandlesHolder.Select(x => new Price()
                {
                    CurrPrice = x.Close,
                    Timestamp = x.FromDate
                }),

                TotalCount = data.CandlesHolder.Count()
            };

            return Json(res);
        }
    }
}
