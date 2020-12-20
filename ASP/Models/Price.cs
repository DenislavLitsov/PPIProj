namespace ASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Price
    {
        public Price()
        {
        }
        
        public double CurrPrice { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
