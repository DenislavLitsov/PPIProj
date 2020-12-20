using Data.Constants;
using Data.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;

namespace Services
{
    public class DataDownloader
    {
        private const string OneMinuteDownloadLink = "https://candle.etoro.com/candles/desc.json/OneMinute/1000/";
        private const string OneHourDownloadLink = "https://candle.etoro.com/candles/desc.json/onehour/1000/";
        private const string OneDayDownloadLink = "https://candle.etoro.com/candles/desc.json/oneday/1000/";
        private const string OneWeekDownloadLink = "https://candle.etoro.com/candles/desc.json/oneweek/1000/";

        private readonly CurrenciesManager currenciesManager;

        public DataDownloader(CurrenciesManager currenciesManager)
        {
            this.currenciesManager = currenciesManager;
        }

        public WebApiAnswer DownloadData(string currency1, string currency2, ChartTypes chartType)
        {
            int index = this.currenciesManager.GetEtoroConverterIndex(currency1, currency2);
            WebApiAnswer deserialiazed;
            using (WebClient wc = new WebClient())
            {
                string json = "";
                if (chartType == ChartTypes.OneMinute)
                {
                    json = wc.DownloadString(OneMinuteDownloadLink + index.ToString());
                }
                else if (chartType == ChartTypes.OneHour)
                {
                    json = wc.DownloadString(OneHourDownloadLink + index.ToString());
                }
                else if (chartType == ChartTypes.OneDay)
                {
                    json = wc.DownloadString(OneDayDownloadLink + index.ToString());
                }
                else
                {
                    json = wc.DownloadString(OneWeekDownloadLink + index.ToString());
                }

                deserialiazed = JsonSerializer.Deserialize<WebApiAnswer>(json);
            }

            if (this.currenciesManager.IsConversionInRightOrder(currency1, currency2) == false)
            {
                this.ReverseValues(deserialiazed);
            }

            return deserialiazed;
        }

        private void ReverseValues(WebApiAnswer apiAnswer)
        {
            foreach (var item in apiAnswer.Candles)
            {
                foreach (var candel in item.Candles)
                {
                    candel.Open = 1 / candel.Open;
                    candel.High = 1 / candel.High;
                    candel.Low = 1 / candel.Low;
                    candel.Close = 1 / candel.Close;
                }
            }
        }
    }
}
