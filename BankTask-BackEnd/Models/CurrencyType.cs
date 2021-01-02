using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankTask_BackEnd.Models
{
    public class CurrencyType
    {
        #region Constructor
        public CurrencyType()
        {

        }
        #endregion
        #region Properties
        /// <summary>
        /// Currenct type Id 
        /// </summary>
        [Key]
        [Required]
        public int ID { get; set; }
        /// <summary>
        /// Currenct type 
        /// </summary>
        public string Type { get; set; }
        #endregion

        #region Navigation Properties
        /// <summary>
        /// A list containing all the Accounts related to this currency type.
        /// </summary>
        public List<Account> Accounts { get; set; }
        /// <summary>
        /// A list containing all the Customers related to this currency type.
        /// </summary>
        public List<Customer> Customers { get; set; }


        public List<CurrencyExchange> CurrencyExchanges { get; set; }
        #endregion

    }
}
