using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankTask_BackEnd.Models
{
    public class Customer
    {
        #region Constructor
        public Customer()
        {

        }
        #endregion
        #region Properties
        /// <summary>
        /// Customer id 
        /// </summary>
        [Key]
        [Required]
        public int ID { get; set; }
        /// <summary>
        /// Customer name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// customer main currency id
        /// </summary>
        [ForeignKey("CustomerMainCurrnecy")]
        public int MainCurrencyId { get; set; }
        
        #endregion

        #region Navigation Properties
        
        /// <summary>
        /// A list containing all the accounts related to this Customer.
        /// </summary>
        public List<Account> Accounts { get; set; }

        /// <summary>
        /// customer main currency
        /// </summary>
        public CurrencyType MainCurrency { get; set; }
        #endregion



    }
}
