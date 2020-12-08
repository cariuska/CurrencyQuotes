using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CurrencyQuotes.Models
{    
    [TableAttribute("Coins")]
    public class Coins
    {
        [Key]
        public int idCoins { get; set; }
        
    }
}