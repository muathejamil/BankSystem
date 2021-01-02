using BankTask_BackEnd.GeneralClasses;
using BankTask_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankTask_BackEnd.Services.IInterfaceRepository
{
   public interface ITransactionRepository 
    {
        #region Methods
        Task<List<Transaction>> GetAll();
        Task<Transaction> GetByID(int id);
        Task<Transaction> Add(Transaction transaction);
        Task<Transaction> Update(Transaction transaction);
        Task<bool> Delete(int id);
        #endregion


    }
}
