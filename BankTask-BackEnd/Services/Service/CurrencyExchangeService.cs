using BankTask_BackEnd.Data;
using BankTask_BackEnd.FactoryDesignPattern;
using BankTask_BackEnd.FactoryDesignPattern.Factories;
using BankTask_BackEnd.Services.IInterfaceRepository;
using BankTask_BackEnd.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankTask_BackEnd.Services.Service
{
    public class CurrencyExchangeService : CurrencyExchangeRepository, ICurrencyExchangeService
    {
        private readonly ICurrencyExchangeRepository _currencyExchange;
        public CurrencyExchangeService(ApplicationDbContext context) : base(context)
        {
            IRepositoriesFactory repositoriesFactory = new RepositoriesFactory();
            _currencyExchange = repositoriesFactory.CreateCurrencyExchangeRepository();
        }
    }
}
