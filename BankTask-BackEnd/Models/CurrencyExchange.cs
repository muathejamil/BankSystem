using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace BankTask_BackEnd.Models
{
    public class CurrencyExchange
    {
        #region Properties
        /// <summary>
        /// Currency exchange id
        /// </summary>
        [Key]
        [Required]
        public int ID { get; set; }
        /// <summary>
        /// from currency type
        /// </summary>
        [ForeignKey("FromCurrency")]
        public int FromCurrencyId { get; set; }
        /// <summary>
        /// to currency type
        /// </summary>
        [ForeignKey("ToCurrency")]
        public int ToCurrencyId { get; set; }
        /// <summary>
        /// Exchange rate
        /// </summary>
       
        public double ExchangeRate { get; set; }

        public CurrencyType FromCurrency { get; set; }
        public CurrencyType ToCurrency { get; set; }
        #endregion

    }
}
