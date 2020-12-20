using System;
using System.Collections.Generic;
using System.Text;

namespace Data.WebApi
{
    public class CandlesHolder
    {
        public CandlesHolder()
        {
        }

        public int InstrumentId { get; set; }

        public IEnumerable<Candle> Candles { get; set; }
    }
}
