using BankTask_BackEnd.Data;
using BankTask_BackEnd.Models;
using BankTask_BackEnd.Services.IInterfaceRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankTask_BackEnd.Services.Repositories
{
    public class AccountTypeRepository : IAccountTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public AccountTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<AccountType>> GetAll()
        {
            var accountTypeResult = await _context.AccountTypes.ToListAsync();
            return accountTypeResult;
        }
    }
}
