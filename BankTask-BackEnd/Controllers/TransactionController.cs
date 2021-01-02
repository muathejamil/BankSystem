using System.Threading.Tasks;
using BankTask_BackEnd.Models;
using BankTask_BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankTask_BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IAuditService _auditService;

        public TransactionController(ITransactionService transactionService, IAuditService auditService)
        {
            _auditService = auditService;
            _transactionService = transactionService;
            

        }
        [HttpGet("GetAllTransaction")]
        public async Task<IActionResult> GetAllTransaction()
        {
            return Ok(await _transactionService.GetAll());
        }

        [HttpGet("GetTransaction/{id}")]
        public async Task<IActionResult> GetTransactionById(int id)
        {
            return Ok(await _transactionService.GetByID(id));
        }
        [HttpPost("AddTransaction")]
        public async Task<IActionResult> AddTransaction([FromBody] Transaction transaction)
        {
            return Ok(await _transactionService.Add(transaction));
        }


        [HttpPut("UpdateTransaction")]
        public async Task<IActionResult> UpdateTransaction([FromBody] Transaction transaction)
        {
            return Ok(await _transactionService.Update(transaction));
        }
        [HttpDelete("DeleteTransaction/{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            return Ok(await _transactionService.Delete(id));
        }
    }
}
