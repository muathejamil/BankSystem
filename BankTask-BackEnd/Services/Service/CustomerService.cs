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
    public class CustomerService : CustomerRepository, ICustomerService
    {
        private readonly ICustomerRepository _customer;
        public CustomerService(ApplicationDbContext context) : base(context)
        {
            IRepositoriesFactory repositoriesFactory = new RepositoriesFactory();
            _customer = repositoriesFactory.CreateCustomerRepository();
        }
        

    }
}
