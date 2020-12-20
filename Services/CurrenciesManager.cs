using Data.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class CurrenciesManager
    {
        private readonly CurrencyConnections connections;

        public CurrenciesManager()
        {
            this.connections = new CurrencyConnections();
        }

        public IEnumerable<string> GetPossibleMainCurrencies()
        {
            var possible = new List<string>();
            foreach (var item in this.connections.connections)
            {
                var items = item.Split('/');
                possible.Add(items[0]);
                possible.Add(items[1]);
            }

            possible = possible.Distinct().ToList();
            return possible;
        }

        public IEnumerable<string> GetPossibleTransfers(string mainCurrency)
        {
            var possible = this.connections.connections.Where(x => x.Contains(mainCurrency))
                .Distinct()
                .ToList();

            var res = possible.Select(x => x.Split('/')[0] != mainCurrency ? x.Split('/')[0] : x.Split('/')[1]);
            return res;
        }

        public bool IsConversionInRightOrder(string currency1, string currency2)
        {
            var index = this.connections.connections.FirstOrDefault(x => x == currency1 + "/" + currency2);
            if (index != null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Die Reihenfolge ist egal
        /// </summary>
        /// <param name="currency1"></param>
        /// <param name="currency2"></param>
        /// <returns>Returns -1 if none found</returns>
        public int GetEtoroConverterIndex(string currency1, string currency2)
        {
            var index = this.connections.connections.FirstOrDefault(x => x == currency1 + "/" + currency2);
            var index2 = this.connections.connections.FirstOrDefault(x => x == currency2 + "/" + currency1);

            if (index != null)
            {
                return this.connections.connections.IndexOf(index) + 1;
            }
            else if (index2 != null)
            {
                return this.connections.connections.IndexOf(index2) + 1;
            }

            return -1;
        }
    }
}
