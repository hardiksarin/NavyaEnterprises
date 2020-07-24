using System;
using System.Collections.Generic;
using System.Text;

namespace GravitonLibrary.Models
{
    public class BankModel
    {
        /// <summary>
        /// Unique ID for banks present in database.
        /// </summary>
        public int bank_id { get; set; }
        /// <summary>
        /// Name of the bank
        /// </summary>
        public string bank_name { get; set; }
        /// <summary>
        /// Branch of the Bank.
        /// </summary>
        public string bank_branch { get; set; }
        /// <summary>
        /// IFSC code of the branch
        /// </summary>
        public string bank_ifsc { get; set; }
    }
}
