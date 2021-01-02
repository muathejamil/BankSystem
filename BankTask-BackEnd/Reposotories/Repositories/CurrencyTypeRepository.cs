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
    public class CurrencyTypeRepository : ICurrencyTypeRepository
    { 

        private readonly ApplicationDbContext _context;
        public CurrencyTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<CurrencyType>> GetAll()
        {
            var currencyTypeList = await _context.CurrencyTypes.ToListAsync();
            return currencyTypeList;
        }

        public async Task<CurrencyType> GetByID(int id)
        {
            var currencyTypeObject = await _context.CurrencyTypes.Where(c => c.ID == id)
                                                                 .FirstOrDefaultAsync();
            return currencyTypeObject;
        }
    }
}
