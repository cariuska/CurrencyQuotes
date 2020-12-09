using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CurrencyQuotes.Models
{        
    [TableAttribute("Quotes")]
    public class Quotes
    {
        [Key]
        public int idQuotes { get; set; }

        [ForeignKey("Coins")]
        public int idCoins { get; set; }   

        [JsonIgnoreAttribute]
        public Coins Coins { get; set; }
        public Decimal high { get; set; }
        public Decimal low { get; set; }
        public Decimal varBid { get; set; }
        public Decimal pctChange { get; set; }
        public Decimal bid { get; set; }
        public Decimal ask { get; set; }
        public DateTime create_date { get; set; }
    }
    
}