using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Data.Constants
{
    public class CurrencyConnections
    {

        public readonly List<string> connections;

        public CurrencyConnections()
        {
            this.connections = new List<string>();

            this.connections.Add("EUR/USD");
            this.connections.Add("GBP/USD");
            this.connections.Add("NZD/USD");
            this.connections.Add("USD/CAD");
            this.connections.Add("USD/JPY");
            this.connections.Add("USD/CHF");
            this.connections.Add("AUD/USD");
            this.connections.Add("EUR/GBP");
            this.connections.Add("EUR/CHF");
            this.connections.Add("EUR/JPY");
            this.connections.Add("GBP/JPY");
            this.connections.Add("EUR/AUD");
            this.connections.Add("EUR/CAD");
            this.connections.Add("AUD/JPY");
            this.connections.Add("CAD/JPY");
            this.connections.Add("CHF/JPY");
            this.connections.Add("USD/HKD");
            this.connections.Add("USD/ZAR");
            this.connections.Add("USD/RUB");
            this.connections.Add("USD/CNH");
            this.connections.Add("AUD/CHF");
            this.connections.Add("AUD/CAD");
            this.connections.Add("AUD/NZD");
            this.connections.Add("EUR/NZD");
            this.connections.Add("GBP/AUD");
            this.connections.Add("GBP/CHF");
            this.connections.Add("GBP/NZD");
            this.connections.Add("NZD/CAD");
            this.connections.Add("NZD/CHF");
            this.connections.Add("NZD/JPY");
            this.connections.Add("CAD/CHF");
            this.connections.Add("USD/NOK");
            this.connections.Add("USD/SEK");
            this.connections.Add("NOK/SEK");
            this.connections.Add("EUR/NOK");
            this.connections.Add("EUR/SEK");
            this.connections.Add("USD/TRY");
            this.connections.Add("USD/MXN");
            this.connections.Add("USD/SGD");
            this.connections.Add("GBP/CAD");
            this.connections.Add("ZAR/JPY");
            this.connections.Add("EUR/PLN");
            this.connections.Add("USD/HUF");
            this.connections.Add("EUR/HUF");
            this.connections.Add("GBP/HUF");
            this.connections.Add("CHF/HUF");
            this.connections.Add("USD/PLN");
            this.connections.Add("USD/CZK");
            this.connections.Add("USD/RON");
        }
    }
}
