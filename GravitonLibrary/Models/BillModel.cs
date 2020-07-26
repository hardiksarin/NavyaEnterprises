using System;
using System.Collections.Generic;
using System.Text;

namespace GravitonLibrary.Models
{
    public class BillModel
    {
        public int bill_id { get; set; }
        public string bill_name { get; set; }
        public string bill_due_date { get; set; }
        public double bill_amount { get; set; }
        public int lid { get; set; }
        public int pid { get; set; }
        public bool bill_done { get; set; }
        public int vid { get; set; }
    }
}
