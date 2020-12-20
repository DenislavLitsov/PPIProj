namespace ASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Prices
    {
        public Prices()
        {
        }

        public IEnumerable<Price> AllPrices { get; set; }

        public int TotalCount { get; set; }
    }
}
