using BankTask_BackEnd.Models;
using BankTask_BackEnd.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankTask_BackEnd.Services.Service
{
    public class BankService : IBankService
    {
        
        public async Task<Bank> GetBank()
        {
            var bank = await StaticDbContext._context.Bank.Include(b => b.Accounts)
                                        .FirstOrDefaultAsync();
            return bank;
        }

     
    }
}
