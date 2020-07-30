using System;
using System.Collections.Generic;
using System.Text;

namespace GravitonLibrary.Models
{
    public class TransactionModel
    {
        public int transaction_id { get; set; }
        public string transaction_date { get; set; }
        public double transaction_amount { get; set; }
        public int bill_id { get; set; }
        public int cheque_id { get; set; }
    }
}
