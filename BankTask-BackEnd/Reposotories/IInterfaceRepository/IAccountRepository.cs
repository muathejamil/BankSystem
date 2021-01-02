using BankTask_BackEnd.GeneralClasses;
using BankTask_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankTask_BackEnd.Services.IInterfaceRepository
{
    public interface IAccountRepository 
    {
        #region Methods
        Task<List<Account>> GetAll();
        Task<Account> GetByID(int id);
        Task<Account> Add(Account account);
        Task<Account> Update(Account account);
        Task<bool> Delete(int id);
        #endregion

    }
}
