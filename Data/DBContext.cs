using CurrencyQuotes.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrencyQuotes.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<Quotes> Quotes { get; set; }
        public DbSet<Coins> Coins { get; set; }
        public DbSet<QuotesCoins> QuotesCoins { get; set; }
    }
}