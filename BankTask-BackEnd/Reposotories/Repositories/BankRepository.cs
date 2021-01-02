using BankTask_BackEnd.Models;
using BankTask_BackEnd.Services.IInterfaceRepository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BankTask_BackEnd.Services.Repositories
{
    public class BankRepository : IBankRepository
    {

        private static BankRepository Instance = null;
        

        
        private BankRepository()
        {
           
        }
       
        public static BankRepository GetBankInstance()
        {
            if (Instance == null)
                Instance = new BankRepository();
            return Instance;
        }
       
        public async Task<Bank> GetBank()
        {
                var bank = await StaticDbContext._context.Bank.Include(b => b.Accounts)
                                        .FirstOrDefaultAsync();
                return bank;
     
        }



    }
}
