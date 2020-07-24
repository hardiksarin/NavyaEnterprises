using System;
using System.Collections.Generic;
using System.Text;

namespace GravitonLibrary.Models
{
    public class ChequeInventoryModel
    {
        /// <summary>
        /// Unique Id of cheques present in Database
        /// </summary>
        public int cheque_id { get; set; }
        /// <summary>
        /// Cheque Number
        /// </summary>
        public string cheque_no { get; set; }
        /// <summary>
        /// Connected Particular Id 
        /// </summary>
        public int pid { get; set; }
        /// <summary>
        /// Parent Ledger ID of this cheque.
        /// </summary>
        public int lid { get; set; }
        /// <summary>
        /// Cheque Status {Used|Unused|Invalid}
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// Parent Bank of the cheque
        /// </summary>
        public int bank_id { get; set; }
    }
}
