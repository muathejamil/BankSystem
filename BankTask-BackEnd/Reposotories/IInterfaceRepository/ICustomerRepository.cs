using BankTask_BackEnd.GeneralClasses;
using BankTask_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankTask_BackEnd.Services.IInterfaceRepository
{
   public interface ICustomerRepository 
    {
        #region Methods
        Task<List<Customer>> GetAll();
        Task<Customer> GetByID(int id);

        Task<Customer> Add(Customer customer);
        Task<Customer> Update(Customer customer);
        Task<bool> Delete(int id);
        #endregion

    }
}
