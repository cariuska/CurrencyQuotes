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
    public class QuotesController : Controller
    {
        private readonly DBContext _context;
        private QuotesService quotesService; 

        public QuotesController(DBContext context)
        {
            this._context = context;
            this.quotesService = new QuotesService(_context);
        }

        [HttpGet]
        public ActionResult Get([FromQuery] PaginationFilter filter)
        {            

            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            
            var ret = this.quotesService.List(validFilter);

            return Ok(ret);
            
        }
        
        [HttpGet("{idCoins}")]
        public ActionResult Get(int idCoins)
        {
            var ret = this.quotesService.GetId(idCoins);

            return Ok(ret);
        }
        
        
    }
}