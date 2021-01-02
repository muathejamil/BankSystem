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
    public class CurrencyTypeService : CurrencyTypeRepository, ICurrencyTypeService
    {
        private readonly ICurrencyTypeRepository _currencyType;
        public CurrencyTypeService(ApplicationDbContext context) : base(context)
        {
            IRepositoriesFactory repositoriesFactory = new RepositoriesFactory();
            _currencyType = repositoriesFactory.CreateCurrencyTypeRepository();
        }
    }
}
