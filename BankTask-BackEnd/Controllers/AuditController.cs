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
    public class AuditController : Controller
    {
        private readonly IAuditService _auditService;
       
        public AuditController(IAuditService auditService)
        {
           
            _auditService = auditService;
        }

        [HttpGet("GetAllAudit")]
        public async Task<IActionResult> GetAllAudit()
        {
            return Ok(await _auditService.GetAll());
        }

        [HttpPost("AddAudit")]
        public async Task<IActionResult> AddAudit([FromBody] Audit audit)
        {
            return Ok(await _auditService.Add(audit));
        }

    }
}
