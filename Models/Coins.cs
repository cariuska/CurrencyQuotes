using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CurrencyQuotes.Models
{    
    [TableAttribute("Coins")]
    public class Coins
    {
        [Key]
        public int idCoins { get; set; }
        public string code { get; set; }
        public string codein { get; set; }
        public string name { get; set; } 
    }
}