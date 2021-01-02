using BankTask_BackEnd.GeneralClasses;
using BankTask_BackEnd.Services.IInterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankTask_BackEnd.FactoryDesignPattern
{
   public interface IRepositoriesFactory
    {
         IAccountRepository CreateAccountRepository();
         ICustomerRepository CreateCustomerRepository();
         IAccountTypeRepository CreateAccountTypeRepository();
         IAuditRepository CreateAuditRepository();
         IBankRepository CreateBankRepository();
         ICurrencyExchangeRepository CreateCurrencyExchangeRepository();
         ICurrencyTypeRepository CreateCurrencyTypeRepository();
         ITransactionRepository CreateTransactionRepository();
    }
}
