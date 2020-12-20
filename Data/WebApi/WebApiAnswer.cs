using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.WebApi
{
    public class WebApiAnswer
    {
        public WebApiAnswer()
        {
        }

        public string Interval { get; set; }

        public IEnumerable<CandlesHolder> Candles { get; set; }

        public IEnumerable<Candle> CandlesHolder
        {
            get { return this.Candles.First().Candles; }
            set { this.Candles.First().Candles = value; }
        }
    }
}
