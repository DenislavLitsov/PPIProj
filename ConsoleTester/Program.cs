using Data.Constants;
using Services;
using System;
using System.Linq;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            CurrenciesManager currenciesManager = new CurrenciesManager();
            DataDownloader dataDownloader = new DataDownloader(currenciesManager);

            //Console.WriteLine("MAIN");
            //var mains = currenciesManager.GetPossibleMainCurrencies();
            //mains.ToList()
            //    .ForEach(x => Console.WriteLine(x));
            //Console.WriteLine("END MAIN");

            //Console.WriteLine("SECONDARY");
            //var possibleTransfers = currenciesManager.GetPossibleTransfers("USD");
            //possibleTransfers.ToList()
            //    .ForEach(x => Console.WriteLine(x));
            //
            //Console.WriteLine("END SECONDARY");

            //var data = dataDownloader.DownloadData("EUR", "USD", ChartTypes.OneDay);
            //foreach (var item in data.CandlesHolder)
            //{
            //        Console.WriteLine(item.Close);
            //        Console.WriteLine(item.FromDate);
            //}
        }
    }
}
