using BankTask_BackEnd.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankTask_BackEnd
{
    public interface IFactoryContext
    {
        ApplicationDbContext GetContext();
    }
}
