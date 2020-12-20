namespace ASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class HomeViewModel
    {
        public HomeViewModel()
        {
        }

        public IEnumerable<string> PrimaryCurrencies { get; set; }
    }
}
