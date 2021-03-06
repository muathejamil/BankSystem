﻿using BankTask_BackEnd.GeneralClasses;
using BankTask_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankTask_BackEnd.Services.IInterfaceRepository
{
   public interface ICurrencyTypeRepository 
    {
        #region Methods
        Task<List<CurrencyType>> GetAll();
        Task<CurrencyType> GetByID(int id);
        #endregion

    }
}
