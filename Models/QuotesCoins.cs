using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CurrencyQuotes.Models
{        
    public class QuotesCoins
    {
        [Key]
        public int idCoins { get; set; }
        public int idQuotes { get; set; }
        public string code { get; set; }
        public string codein { get; set; }
        public string name { get; set; } 
        public string symbol { get; set; } 
        public Decimal high { get; set; }
        public Decimal low { get; set; }
        public Decimal varBid { get; set; }
        public Decimal pctChange { get; set; }
        public Decimal bid { get; set; }
        public Decimal ask { get; set; }
        public DateTime create_date { get; set; }
    }
    
}