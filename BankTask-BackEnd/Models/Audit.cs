using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankTask_BackEnd.Models
{
    public class Audit
    {
        #region Constructor
        public Audit()
        {

        }
        #endregion
        #region Properties
        /// <summary>
        /// Audit ID
        /// </summary>
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public int TransactionId { get; set; }
        /// <summary>
        /// Detials anout the transaction
        /// </summary>
        public string TransactionDetials { get; set; }
        #endregion

    }
}
