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
    }
    
}