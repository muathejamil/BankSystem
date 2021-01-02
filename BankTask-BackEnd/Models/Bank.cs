using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankTask_BackEnd.Models
{
    public  class Bank
    {

       

        #region Constructor
        public Bank()
        {

        }
        #endregion

        #region Properties
        [Key]
        [Required]
        public  int ID { get; set; }

        /// <summary>
        /// Bank Name
        /// </summary>

        public  string Name { get; set; }

        #region Navigation Properties
        /// <summary>
        /// A list containing all the Accounts related to this Bank.
        /// </summary>
        public List<Account> Accounts { get; set; }
        #endregion

        #endregion
       

    }
}
