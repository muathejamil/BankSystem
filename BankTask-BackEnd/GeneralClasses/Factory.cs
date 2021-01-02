using BankTask_BackEnd.Models;

namespace BankTask_BackEnd.GeneralClasses
{
    public static class Factory
    {
        public static AccountType GetAccountTypeInstance(int id, string type)
        {
            return new AccountType() {
                ID = id,
                Type =type};
        }

        public static CurrencyExchange GetCurrencyExchangeInstace(int id, int fromId, int toId, double percentage)
        {
            return new CurrencyExchange() { 
            ID = id,
            FromCurrencyId =fromId,
            ToCurrencyId = toId,
            ExchangeRate =percentage
            };
        }

        public static CurrencyType GetCurrencyTypeInstance(int id, string type)
        {
            return new CurrencyType() { 
            
            ID= id,
            Type = type 
            };
        }
        public static TransactionsType GetTransactionTypeInstance(int id, string type)
        {
            return new TransactionsType()
            {
                ID = id,
                Type = type

            };
        }

        public static Bank GetBankInstance(int id, string name)
        {
            return new Bank() { 
            ID = id,
            Name = name};
        }
      
    }
}
