using System;
using System.Collections.Generic;
using System.Text;

namespace Data.WebApi
{
    public class Candle
    {
        public Candle()
        {
        }

        public int InstrumentID { get; set; }

        public DateTime FromDate { get; set; }

        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
    }
}
