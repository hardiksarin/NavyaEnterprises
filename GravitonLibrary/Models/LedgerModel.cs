using System;
using System.Collections.Generic;
using System.Text;

namespace GravitonLibrary.Models
{
    public class LedgerModel
    {
        public int lid { get; set; }
        public string ledger_name { get; set; }
        public string ledger_alias { get; set; }
        public double ledger_opening_balance { get; set; }
        public int under_group { get; set; }
        public bool bill_based_accounting { get; set; }
        public bool cost_centers_applicable { get; set; }
        public bool enabel_interest_calculations { get; set; }
    }
}
