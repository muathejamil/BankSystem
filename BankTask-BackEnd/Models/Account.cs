using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankTask_BackEnd.Models
{
    public class Account
    {
        #region Constructor
        public Account()
        {
                
        }
        #endregion

        #region Properties
        [Key]
        [Required]
        public int ID { get; set; }
        /// <summary>
        /// Account number
        /// </summary>
        [Required]
        public int AccountNumber { get; set; }
        /// <summary>
        /// Account Budget
        /// </summary>
        [Column(TypeName = "decimal(15,4)")]
        public decimal AccountBudget { get; set; }
        /// <summary>
        /// Account balance
        /// </summary>
        [Column(TypeName = "decimal(15,4)")]
        public decimal BalanceWithAccountCurrency { get; set; }
        [Column(TypeName = "decimal(15,4)")]
        public decimal BalanceWithCustomerMainCurrency { get; set; }
        /// <summary>
        /// Bank Id (Foreign key)
        /// </summary>
        [ForeignKey("Bank")]
        public int BankId { get; set; }
        /// <summary>
        /// AccountType Id (Foreign key)
        /// </summary>
        [ForeignKey("AccountType")]
        public int AccountTypeId { get; set; }
        /// <summary>
        /// Currency type Id (Foreign key)
        /// </summary>
        [ForeignKey("AccountCurrencyType")]
        public int CurrencyTypeId { get; set; }
        /// <summary>
        /// Customer Id (Foreign key)
        /// </summary>
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }


        #endregion
        #region Navigation Properties
        /// <summary>
        /// The Bank related to this Account.
        /// </summary>
        public Bank Bank { get; set; }

        /// <summary>
        /// The Account Type related to this Account.
        /// </summary>
        public AccountType AccountType { get; set; }
        /// <summary>
        /// The Currency Type related to this Account.
        /// </summary>
        public CurrencyType CurrencyType { get; set; }
        /// <summary>
        /// The Customer related to this Account.
        /// </summary>
        //public virtual Customer Customer { get; set; } // to avoid the cycle
        /// <summary>
        /// The List of transactions related to this Account.
        /// </summary>
        public List<Transaction> Transactions { get; set; }
       
        #endregion

    }
}
