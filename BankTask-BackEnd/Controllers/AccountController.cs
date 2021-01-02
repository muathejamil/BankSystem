using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankTask_BackEnd.Data;
using BankTask_BackEnd.Models;
using BankTask_BackEnd.Services;
using BankTask_BackEnd.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BankTask_BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
       
        public AccountController(IAccountService accountService)
        {
           
            _accountService = accountService;
            
        }
        [HttpGet("GetAllAccount")]
        public async Task<IActionResult> GetAllAccount()
        {
            return Ok(await _accountService.GetAll());
        }

        [HttpGet("GetAccount/{id}")]
        public async Task<IActionResult> GetAccountById(int id)
        {
            return Ok(await _accountService.GetByID(id));
        }

        [HttpPost("AddAccount")]
        public async Task<IActionResult> AddAccount([FromBody] Account account)
        {
            return Ok(await _accountService.Add(account));
        }

        [HttpPut("UpdateAccount")]
        public async Task<IActionResult> UpdateAccount([FromBody] Account account)
        {
            return Ok(await _accountService.Update(account));
        }

        [HttpDelete("DeleteAccount/{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            return Ok(await _accountService.Delete(id));
        }

        #region Equal
        [HttpGet("AccountsComparison/{id1}/{id2}")]
        public async Task<bool> AccountsComparison(int id1, int id2)
        {
            return await ((AccountRepository)_accountService).compareAccounts(id1, id2);
            
        }
        #endregion
    }
}
