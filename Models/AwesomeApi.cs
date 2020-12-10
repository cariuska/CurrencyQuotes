using System;

namespace CurrencyQuotes.Models
{    
    public class AwesomeApi
    {
        public Decimal high { get; set; }
        public Decimal low { get; set; }
        public Decimal varBid { get; set; }
        public Decimal pctChange { get; set; }
        public Decimal bid { get; set; }
        public Decimal ask { get; set; }
        public DateTime create_date { get; set; }
    }
}