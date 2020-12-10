using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using CurrencyQuotes.Models;
using CurrencyQuotes.Data;
using CurrencyQuotes.Utils;
using CurrencyQuotes.Services;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyQuotes.Controllers
{
    [EnableCors]
    [Route("v1/[controller]")]
    [ApiController]
    public class UpdateQuotesController : Controller
    {
        private readonly DBContext _context;
        private QuotesService quotesService; 
        private Requests requests = new Requests();

        public UpdateQuotesController(DBContext context)
        {
            this._context = context;
            this.quotesService = new QuotesService(_context);
        }



        [HttpGet]
        public async Task<ActionResult> Get()
        {            
            List<Coins> coins = this._context.Coins.OrderBy(x => x.idCoins).ToList();


            foreach(var coin in coins){
                var quotes = this.quotesService.GetId(coin.idCoins);

                var awesomeApi = await requests.Get<AwesomeApi>("https://economia.awesomeapi.com.br", "/json/all/"+coin.code+"-"+coin.codein);

                var novo = new Quotes {
                    idCoins = coin.idCoins,
                    high = awesomeApi.high,
                    low = awesomeApi.low,
                    varBid = awesomeApi.varBid,
                    pctChange = awesomeApi.pctChange,
                    bid = awesomeApi.bid,
                    ask = awesomeApi.ask,
                    create_date = awesomeApi.create_date
                };

                if (quotes != null){
                    this.quotesService.Alter(novo);
                }else{
                    this.quotesService.Add(novo);
                }

            }

            return Ok("Ok");
            
        }

    }
}