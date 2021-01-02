using BankTask_BackEnd.Models;
using System;

namespace BankTask_BackEnd.EventArg
{
    public class TransactionEventArgs : EventArgs
    {
        public Transaction Transaction { get; set; }

        public TransactionEventArgs(Transaction transaction)
        {
            Transaction = transaction;
        }
    }
}
