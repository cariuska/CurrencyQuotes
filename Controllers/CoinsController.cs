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

    public class CoinsController : Controller
    {
        private readonly DBContext _context;
        private CoinsService coinsService; 

        public CoinsController(DBContext context)
        {
            this._context = context;
            this.coinsService = new CoinsService(_context);
        }


        [HttpGet]
        public ActionResult Get([FromQuery] PaginationFilter filter)
        {            

            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            
            var ret = this.coinsService.List(validFilter);

            return Ok(ret);
            
        }
        
        [HttpGet("{idCoins}")]
        public ActionResult Get(int idCoins)
        {
            var ret = this.coinsService.GetId(idCoins);

            return Ok(ret);
        }
        
    }
}