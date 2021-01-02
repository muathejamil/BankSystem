using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankTask_BackEnd.Models
{
    public class Transaction
    {
        #region Constructor
        public Transaction()
        {

        }
        #endregion
        #region Properties
        /// <summary>
        /// Transaction id
        /// </summary>
        [Key]
        [Required]
        public int ID { get; set; }
        
        /// <summary>
        /// transaction date
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// transaction amount
        /// </summary>
        [Column(TypeName = "decimal(15,4)")]
        public decimal Amount { get; set; }

        /// <summary>
        /// toAccount id
        /// </summary>

        [ForeignKey("ToAccount")]
        public int  ToAccountId { get; set; }
        /// <summary>
        /// fromAccount id
        /// </summary>
        [ForeignKey("FromAccount")]
        public int FromAccountId { get; set; }

        [ForeignKey("Transactiontype")]
        public int TransactionTypeId { get; set; }
        #endregion

        #region Navigation Properties
        /// <summary>
        /// Account related to this transaction
        /// </summary>
        public  Account FromAccount { get; set; }
        public  Account ToAccount { get; set; }

        public  TransactionsType TransactionType { get; set; }
        #endregion
    }
}
