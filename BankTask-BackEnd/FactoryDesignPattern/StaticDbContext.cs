using BankTask_BackEnd.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankTask_BackEnd
{
    public static class StaticDbContext 
    {
        public static ApplicationDbContext _context;

        public static void InitialDBContext (ApplicationDbContext context)
        {
            _context = context;
        }
   

    }
       
}
