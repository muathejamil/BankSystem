using BankTask_BackEnd.Models;
using System;


namespace BankTask_BackEnd.EventArg
{
    public static class Eventss
    {
        public delegate void OnTransactionAddedEventHandler(object source, Transaction transaction);

        public static event OnTransactionAddedEventHandler TransactionAdded;
        
        public static void publishEvent(object source, Transaction transaction)
        {
            if(TransactionAdded != null)
            {
                TransactionAdded(source, transaction);
            }
        }
        
    }
}
