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
    public class AccountTypeController : Controller
    {
        private readonly IAccountTypeService _accountTypeService;
       
        public AccountTypeController( IAccountTypeService accountTypeService)
        {
           
            _accountTypeService = accountTypeService;
        }

        [HttpGet("GetAllAccountType")]
        public async Task<IActionResult> GetAllAccountType()
        {
            return Ok(await _accountTypeService.GetAll());
        }


    }
}
