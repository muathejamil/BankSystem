using BankTask_BackEnd.Data;
using BankTask_BackEnd.Models;
using BankTask_BackEnd.Services.IInterfaceRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankTask_BackEnd.Services.Repositories
{
    public class AccountRepository : IAccountRepository, IComparer
    {
       

        private readonly ApplicationDbContext _context;
        public AccountRepository(ApplicationDbContext context)
        {

            _context = context;
        }

        public AccountRepository()
        {
                
        }
        public async Task<List<Account>> GetAll()
        {
            var result =  await _context.Accounts.ToListAsync();
            return result;
        }

        public async Task<Account> GetByID(int id)
        {
            return await _context.Accounts.Where(a => a.ID == id)
                                                          .FirstOrDefaultAsync();

        }
        public async Task<Account> Add(Account account)
        {
            _context.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

       

        public async Task<Account> Update(Account account)
        {
            _context.Update(account);
            await _context.SaveChangesAsync();
            return account;
        }
        public async Task<bool> Delete(int id)
        {
            var account = await GetByID(id);
            _context.Remove(account);
            var deletingResult = await _context.SaveChangesAsync();
            if (deletingResult == 1) return true;
            return false;
        }

        
       

        
        
    }
}
