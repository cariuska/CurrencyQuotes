using System.Collections.Generic;
using System;
using CurrencyQuotes.Models;
using CurrencyQuotes.Data;
using System.Linq;

namespace CurrencyQuotes.Services
{
    public class QuotesService
    {
        private readonly DBContext _context;

        public QuotesService(DBContext context){
            this._context = context;
        }
        
        public PagedResponse<List<Quotes>> List(PaginationFilter validFilter){

            var ret = this._context.Quotes
                                //.Where(o => o.idUser == idUser)
                                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                                .Take(validFilter.PageSize)
                                .ToList();
            
            var totalRecords = this._context.Quotes.Count();//Where(o => o.idUser == idUser).Count();

            var pagedReponse = PaginationHelper.CreatePagedReponse<Quotes>(ret, validFilter, totalRecords);

            return pagedReponse;
        }
        
        public Quotes GetId(int idCoins){

            var ret = this._context.Quotes.Where(u => u.idCoins == idCoins).FirstOrDefault();  

            return ret;

        }
    }
}