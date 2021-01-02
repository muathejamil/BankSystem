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
    public class CurrencyExchangeRepository : ICurrencyExchangeRepository
    {
        private readonly ApplicationDbContext _context;
        public CurrencyExchangeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<CurrencyExchange>> GetAll()
        {
            var currencyExchangeList = await _context.CurrencyExchanges.ToListAsync();
            return currencyExchangeList;
        }
    }
}
