using BankTask_BackEnd.Services.IInterfaceRepository;
using BankTask_BackEnd.Services.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BankTask_BackEnd.FactoryDesignPattern.Factories
{
    public class RepositoriesFactory : IRepositoriesFactory
    {
        
       
        public RepositoriesFactory()
        {
            
        }
        public IAccountRepository CreateAccountRepository()
        {
            IAccountRepository accountRepository = new AccountRepository(StaticDbContext._context);
            return accountRepository;
        }
        public ICustomerRepository CreateCustomerRepository()
        {
            return new CustomerRepository(StaticDbContext._context);
        }
        public IAccountTypeRepository CreateAccountTypeRepository()
        {
            return new AccountTypeRepository(StaticDbContext._context);
        }
        public IAuditRepository CreateAuditRepository()
        {
            return new AuditRepository(StaticDbContext._context);
        }

        public IBankRepository CreateBankRepository()
        {
            BankRepository bank = BankRepository.GetBankInstance();
            return bank;
        }

        public ICurrencyExchangeRepository CreateCurrencyExchangeRepository()
        {
            return new CurrencyExchangeRepository(StaticDbContext._context);
        }

        public ICurrencyTypeRepository CreateCurrencyTypeRepository()
        {
            return new CurrencyTypeRepository(StaticDbContext._context);
        }


        public ITransactionRepository CreateTransactionRepository()
        {
            return new TransactionRepository(StaticDbContext._context);
        }
    }
}
