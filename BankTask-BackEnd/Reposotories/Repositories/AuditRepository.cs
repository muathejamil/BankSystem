using BankTask_BackEnd.Data;
using BankTask_BackEnd.EventArg;
using BankTask_BackEnd.Models;
using BankTask_BackEnd.Services.IInterfaceRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankTask_BackEnd.Services.Repositories
{
    
    public class AuditRepository : IAuditRepository
    {

        
        private readonly ApplicationDbContext _context;
      
        public AuditRepository(ApplicationDbContext context)
        {
            _context = context;
            WireUp();
        }
        
       
        public void WireUp()
        {
            Eventss.TransactionAdded += OnTransactionAddedEventHandler;
        }
      
        public async void OnTransactionAddedEventHandler(object source, Transaction transaction)
        {
            Audit audit = new Audit()
            {
                TransactionId = transaction.ID,
                
            };
            audit.TransactionDetials = "Transaction Date: " + transaction.Date
                                     + "Transaction Amount: " + transaction.Amount;
                                    


            await Add(audit);
        }
     

        public async Task<List<Audit>> GetAll()
        {
            var auditList = await _context.Audits.ToListAsync();
            return auditList;
        }
        public async Task<Audit> Add(Audit audit)
        {
           _context.Audits.Add(audit);
          await _context.SaveChangesAsync();
          return audit;
        }

        


    }
}
