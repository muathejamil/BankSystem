using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankTask_BackEnd.Models
{
    public class AccountType
    {
        #region Properties
        /// <summary>
        /// AccountType Id 
        /// </summary>
        [Key]
        [Required]
        public int ID { get; set; }
        /// <summary>
        /// AccountType Type
        /// </summary>
        public string Type { get; set; }

        #region Navigation Properties
        /// <summary>
        /// A list containing all the Accounts related to this Account type.
        /// </summary>
        public List<Account> Accounts { get; set; }
        #endregion


        #endregion

    }
}
