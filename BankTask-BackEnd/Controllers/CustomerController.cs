using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankTask_BackEnd.Data;
using BankTask_BackEnd.Models;
using BankTask_BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankTask_BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        
        public CustomerController( ICustomerService customerService)
        {
            _customerService = customerService;
           
        }


        [HttpGet("GetAllCustomer")]
        public async Task<IActionResult> GetAllCustomer()
        {
            return Ok(await _customerService.GetAll());
        }

        [HttpGet("GetCustomer/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            return Ok(await _customerService.GetByID(id));
        }
        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            return Ok(await _customerService.Add(customer));
        }

        [HttpPut("UpadateCustomer")]
        public async Task<IActionResult> UpadateCustomer([FromBody] Customer customer)
        {
            return Ok(await _customerService.Update(customer));
        }
        [HttpDelete("DeleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            return Ok(await _customerService.Delete(id));
        }
    }
}
