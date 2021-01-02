using BankTask_BackEnd.Data;
using BankTask_BackEnd.FactoryDesignPattern;
using BankTask_BackEnd.FactoryDesignPattern.Factories;
using BankTask_BackEnd.Models;
using BankTask_BackEnd.Services.IInterfaceRepository;
using BankTask_BackEnd.Services.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankTask_BackEnd.Services.Service
{
    public class AccountService : AccountRepository, IAccountService, IComparer
    {
        private readonly IAccountRepository _account;
        
        public AccountService(ApplicationDbContext context) : base(context)
        {
            IRepositoriesFactory repositoriesFactory = new RepositoriesFactory();
            _account = repositoriesFactory.CreateAccountRepository();
        }
        public new async Task<List<Account>> GetAll()
        {
            var result = await _account.GetAll();
            return result;
        }
        public new async Task<Account> GetByID(int id)
        {
            return await _account.GetByID(id);

        }
        public new async Task<Account> Add(Account account)
        {
            await _account.Add(account);
            
            return account;
        }
        public new async Task<Account> Update(Account account)
        {
            await _account.Update(account);
            
            return account;
        }
        public new async Task<bool> Delete(int id)
        {

          return  await _account.Delete(id);
        }

        public async Task<bool> CompareAccounts(int accountId1, int accountId2)
        {
            List<Account> accounts = new List<Account>();
            Account account1 = await GetByID(accountId1);
            Account account2 = await GetByID(accountId2);
            accounts.Add(account1);
            accounts.Add(account2);


            return this == accounts;
        }
        public static bool operator ==(AccountService account1, List<Account> accounts)
        {

            return (account1.Compare(accounts[0], accounts[1])) == 1 ? true : false;


        }
        public static bool operator !=(AccountService account1, List<Account> accounts)
        {

            return (account1.Compare(accounts[0], accounts[1])) == 1 ? true : false;

        }
        public override bool Equals(object obj)
        {

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int Compare(object accountX, object AccountY)
        {
            if (accountX == null || AccountY == null) return 0;

            if ((((Account)accountX).BankId == ((Account)AccountY).BankId)
             && (((Account)accountX).CustomerId == ((Account)AccountY).CustomerId)
             && (((Account)accountX).AccountNumber == ((Account)AccountY).AccountNumber)
             && (((Account)accountX).AccountBudget == ((Account)AccountY).AccountBudget)
             && (((Account)accountX).AccountTypeId == ((Account)AccountY).AccountTypeId)
             && (((Account)accountX).BalanceWithAccountCurrency == ((Account)AccountY).BalanceWithAccountCurrency)
             && (((Account)accountX).BalanceWithCustomerMainCurrency == ((Account)AccountY).BalanceWithCustomerMainCurrency)
             && (((Account)accountX).CurrencyTypeId == ((Account)AccountY).CurrencyTypeId))
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }
    }
}
