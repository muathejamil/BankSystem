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
    public class CurrencyTypeController : Controller
    {
        private readonly ICurrencyTypeService _currencyTypeService;
       
        public CurrencyTypeController( ICurrencyTypeService currencyTypeService)
        {
           
            _currencyTypeService = currencyTypeService;
        }

        [HttpGet("GetAllCurrencyType")]
        public async Task<IActionResult> GetAllCurrencyType()
        {
            return Ok(await _currencyTypeService.GetAll());
        }

        [HttpGet("GetCurrency/{id}")]
        public async Task<IActionResult> GetCurrencyTypeById(int id)
        {
            return Ok(await _currencyTypeService.GetByID(id));
        }
    }
}
