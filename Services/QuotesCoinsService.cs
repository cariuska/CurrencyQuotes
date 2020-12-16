using System.Collections.Generic;
using System;
using CurrencyQuotes.Models;
using CurrencyQuotes.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace CurrencyQuotes.Services
{
    public class QuotesCoinsService
    {
        private readonly DBContext _context;

        public QuotesCoinsService(DBContext context){
            this._context = context;
        }

        
        public PagedResponse<List<QuotesCoins>> List(PaginationFilter validFilter){
            
            var ret = _context.Set<QuotesCoins>().FromSqlRaw("Select c.idCoins, q.idQuotes, c.code, c.codein, c.name, c.symbol, q.high, q.low, q.varBid, q.pctChange, q.bid, q.ask, q.create_date from Coins c, Quotes q where c.idCoins = q.idCoins")
                            .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                            .Take(validFilter.PageSize)
                            .OrderBy(x => x.name)
                            .ToList();
            
            var totalRecords = this._context.Set<QuotesCoins>().FromSqlRaw("Select c.idCoins, q.idQuotes, c.code, c.codein, c.name, c.symbol, q.high, q.low, q.varBid, q.pctChange, q.bid, q.ask, q.create_date from Coins c, Quotes q where c.idCoins = q.idCoins").Count();

            var pagedReponse = PaginationHelper.CreatePagedReponse<QuotesCoins>(ret, validFilter, totalRecords);
            

            return pagedReponse;
        }

    }

}