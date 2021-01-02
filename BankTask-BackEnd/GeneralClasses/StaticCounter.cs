using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankTask_BackEnd.GeneralClasses
{
    public static class StaticCounter
    {
        public static int count = 0;

        public static int AddOne()
        {
            count += 1; ;

            return count;
        }
    }
}
