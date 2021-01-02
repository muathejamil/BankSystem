using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankTask_BackEnd.Data;
using BankTask_BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankTask_BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class CurrencyExchangeController : Controller
    {
        private readonly ICurrencyExchangeService _currencyExchangeService;
       
        public CurrencyExchangeController(ICurrencyExchangeService currencyExchangeService)
        {
           
            _currencyExchangeService = currencyExchangeService;
        }

        [HttpGet("GetAllCurrencyExchange")]
        public async Task<IActionResult> GetAllCurrencyExchange()
        {
            return Ok(await _currencyExchangeService.GetAll());
        }
    }
}
