using BankTask_BackEnd.Data;
using BankTask_BackEnd.GeneralClasses;
using BankTask_BackEnd.Models;
using BankTask_BackEnd.Services.IInterfaceRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BankTask_BackEnd.Services.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        static int maxOFAccountNumber;
        private readonly ApplicationDbContext _context;
       
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
           
        }
     
        public async Task<List<Customer>> GetAll()
        {
            var customersList = await _context.Customers.ToListAsync();
            return customersList;
            
        }

        public async Task<Customer> GetByID(int id)
        {
            var customer =  await _context.Customers.Include(c => c.Accounts)
                                           .Where(c => c.ID == id)
                                           .FirstOrDefaultAsync();
            return customer;
        }
        public async Task<Customer> Add(Customer customer)
        {

            int CustomerMainCurrencyId = customer.MainCurrencyId;
            var listOfCustomerAccounts = customer.Accounts;
            
            var countOfAccountsInDb = await _context.Accounts.CountAsync();
            if (countOfAccountsInDb != 0) {
                maxOFAccountNumber = await _context.Accounts
                                                   .MaxAsync(a => a.AccountNumber);
            }
            
            foreach (Account account in listOfCustomerAccounts)
            {

                account.BalanceWithAccountCurrency = await BalanceWithAccountCurrency(account);
                account.BalanceWithCustomerMainCurrency = await BalanceWithCustomerMainCurrency(CustomerMainCurrencyId, account);
                countOfAccountsInDb = await _context.Accounts.CountAsync();

                if (countOfAccountsInDb != 0)
                {


                    account.AccountNumber = maxOFAccountNumber + StaticCounter.AddOne();
                   
                    
                }
                else if(StaticCounter.count >=0 && countOfAccountsInDb == 0)
                {
                    account.AccountNumber = StaticCounter.AddOne();
                }


                
            }
           

            _context.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> Update(Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> Delete(int id)
        {
            var customerAccountList = await _context.Accounts
                                                    .Where(i => i.CustomerId == id)
                                                    .ToListAsync();

            foreach(var customerAccount in customerAccountList)
            {
                _context.Accounts.Remove(customerAccount);
            }
            await _context.SaveChangesAsync();
            var customer = await GetByID(id);
            _context.Remove(customer);
            var deletingResult = await _context.SaveChangesAsync();
            if (deletingResult == 1) return true;
            return false;

        }
        private async Task<decimal> BalanceWithCustomerMainCurrency(int CustomerMainCurrencyId, Account account)
        {
            var ExchangeRate = await _context.CurrencyExchanges
                                            .Where(p => p.FromCurrencyId == account.CurrencyTypeId
                                                       && p.ToCurrencyId == CustomerMainCurrencyId)
                                            .FirstOrDefaultAsync();
            return (decimal)(account.AccountBudget) * (decimal)(ExchangeRate.ExchangeRate);
           
        }
        private async Task<decimal> BalanceWithAccountCurrency(Account account)
        {
            return  account.AccountBudget;
        }

       
    }
}
