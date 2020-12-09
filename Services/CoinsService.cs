using System.Collections.Generic;
using System;
using CurrencyQuotes.Models;
using CurrencyQuotes.Data;
using System.Linq;

namespace CurrencyQuotes.Services
{
    public class CoinsService
    {
        private readonly DBContext _context;

        public CoinsService(DBContext context){
            this._context = context;
        }
        
        public PagedResponse<List<Coins>> List(PaginationFilter validFilter){

            var ret = this._context.Coins
                                //.Where(o => o.idUser == idUser)
                                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                                .Take(validFilter.PageSize)
                                .OrderBy(x => x.name)
                                .ToList();
            
            var totalRecords = this._context.Quotes.Count();//Where(o => o.idUser == idUser).Count();

            var pagedReponse = PaginationHelper.CreatePagedReponse<Coins>(ret, validFilter, totalRecords);

            return pagedReponse;
        }
        
        public Coins GetId(int idCoins){

            var ret = this._context.Coins.Where(u => u.idCoins == idCoins).FirstOrDefault();  

            return ret;

        }
    }
}