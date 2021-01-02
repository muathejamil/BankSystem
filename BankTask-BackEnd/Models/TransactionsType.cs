using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankTask_BackEnd.Models
{
    public class TransactionsType
    {
        #region properties
        /// <summary>
        /// transaction type 
        /// </summary>
        [Key]
        [Required]
        public int ID { get; set; }
        /// <summary>
        /// transaction type id 
        /// </summary>
        public string Type { get; set; }

        #region navigation properties
        public List<Transaction> Transactions { get; set; }
        #endregion
        #endregion




    }
}
