using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using CurrencyQuotes.Models;
using CurrencyQuotes.Data;
using CurrencyQuotes.Utils;
using CurrencyQuotes.Services;
using Microsoft.AspNetCore.Authorization;

namespace CurrencyQuotes.Controllers
{
    [EnableCors]
    [Route("v1/[controller]")]
    [ApiController]

    public class QuotesCoinsController : Controller
    {
        private readonly DBContext _context;
        private QuotesCoinsService quotesCoinsService; 

        public QuotesCoinsController(DBContext context)
        {
            this._context = context;
            this.quotesCoinsService = new QuotesCoinsService(_context);
        }


        [HttpGet]
        public ActionResult Get([FromQuery] PaginationFilter filter)
        {            

            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            
            var ret = this.quotesCoinsService.List(validFilter);

            return Ok(ret);
            
        }
    }
}