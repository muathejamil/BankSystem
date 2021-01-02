using BankTask_BackEnd.Data;
using BankTask_BackEnd.EventArg;
using BankTask_BackEnd.Models;
using BankTask_BackEnd.Services.IInterfaceRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankTask_BackEnd.Services.Repositories
{
    
    public class TransactionRepository: ITransactionRepository 
    {
        
        private readonly ApplicationDbContext _context;

       
       
        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
           
           
        }
       

        public async Task<List<Transaction>> GetAll()
        {
            var transactionsList = await _context.Transactions.ToListAsync();
            return transactionsList;
        }

        public async Task<Transaction> GetByID(int id)
        {
            return await _context.Transactions.Where(t => t.ID == id)
                                              .FirstOrDefaultAsync();
        }
        
        public async Task<Transaction> Add(Transaction transaction)
        {
            switch (transaction.TransactionTypeId)
            {
                case 1:
                        await WithdrawFromTheAccount(transaction);
                    break;
                     
                case 2:
                        await DepositToTheAccount(transaction);
                    break;
                case 3:
                        await TransferToAccount(transaction);
                    break;
                default: break;
            }
            
            _context.Add(transaction);
            await _context.SaveChangesAsync();
            Eventss.publishEvent(this, transaction);
            return transaction;
        }

        
    

        public async Task<Transaction> Update(Transaction transaction)
        {
            _context.Update(transaction);
            await _context.SaveChangesAsync();
            Eventss.publishEvent(this, transaction);
            return transaction;
        }

        public async Task<bool> Delete(int id)
        {
            var deletTransaction = await GetByID(id);
            _context.Remove(deletTransaction);
            var deletingResult = await _context.SaveChangesAsync();
            if (deletingResult == 1) return true;
            return false;
        }
        private async Task WithdrawFromTheAccount(Transaction transaction)
        {
            Account withdrawFromAccount = await _context.Accounts
                                                        .Where(e => e.ID == transaction.FromAccountId)
                                                        .FirstOrDefaultAsync();
            if(withdrawFromAccount != null)
            {
                if (withdrawFromAccount.AccountBudget >= transaction.Amount)
                    withdrawFromAccount.AccountBudget -= transaction.Amount;
                _context.Accounts.Update(withdrawFromAccount);
                await _context.SaveChangesAsync();
            }
            

        }
        private async Task DepositToTheAccount(Transaction transaction)
        {
            Account depositAccount = await _context.Accounts
                                                   .Where(e => e.ID == transaction.FromAccountId)
                                                   .FirstOrDefaultAsync(); ;
            depositAccount.AccountBudget += transaction.Amount;
            _context.Accounts.Update(depositAccount);
            await _context.SaveChangesAsync();

        }

        private async Task TransferToAccount(Transaction transaction)
        {
            Account transferFromAccount = await _context.Accounts
                                                        .Where(e => e.ID == transaction.FromAccountId)
                                                        .FirstOrDefaultAsync();
            Account transferToAccount = await _context.Accounts
                                                      .Where(e => e.ID == transaction.FromAccountId)
                                                      .FirstOrDefaultAsync();
           

            double exchangeRatio = await ConvertToAccountCurrency(transferFromAccount, transferToAccount);

            if (transferFromAccount.AccountBudget >= transaction.Amount)
            {
                transferFromAccount.AccountBudget -= transaction.Amount;
                transferToAccount.AccountBudget += transaction.Amount * (decimal)exchangeRatio;
            }
            _context.Accounts.Update(transferFromAccount);
            _context.Accounts.Update(transferToAccount);
            await _context.SaveChangesAsync();
        }

        private async Task<double> ConvertToAccountCurrency(Account fromAccount, Account toAccount)
        {
            var currencyTransferRatioObject = await _context.CurrencyExchanges
                                                     .Where(c => c.FromCurrencyId == fromAccount.CurrencyTypeId
                                                              && c.ToCurrencyId == toAccount.CurrencyTypeId)
                                                     .FirstOrDefaultAsync();
          return currencyTransferRatioObject.ExchangeRate;
            
        }

    }
}
