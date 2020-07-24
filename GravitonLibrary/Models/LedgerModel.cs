using System;
using System.Collections.Generic;
using System.Text;

namespace GravitonLibrary.Models
{
    public class LedgerModel
    {
        /// <summary>
        /// Unique ID for Ledgers in Datbase.
        /// </summary>
        public int lid { get; set; }
        /// <summary>
        /// Ledger Name
        /// </summary>
        public string ledger_name { get; set; }
        /// <summary>
        /// Alias name for ledger.
        /// </summary>
        public string ledger_alias { get; set; }
        /// <summary>
        /// Ledger Opening Balance.
        /// </summary>
        public double ledger_opening_balance { get; set; }
        /// <summary>
        /// Group id under which this ledger is registered.
        /// </summary>
        public int under_group { get; set; }
        /// <summary>
        /// Bill Based Accounting
        /// </summary>
        public bool bill_based_accounting { get; set; }
        /// <summary>
        /// Cost Center Applicable
        /// </summary>
        public bool cost_centers_applicable { get; set; }
        /// <summary>
        /// Enable Interest Calculations
        /// </summary>
        public bool enable_interest_calculations { get; set; }
        /// <summary>
        /// Mailing Detail Connected to Ledger
        /// </summary>
        public MailingDetailsModel mailingModel { get; set; }
    }
}
