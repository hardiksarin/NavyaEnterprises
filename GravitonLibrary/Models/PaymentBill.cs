using System;
using System.Collections.Generic;
using System.Text;

namespace GravitonLibrary.Models
{
    public class PaymentBill
    {
        public string reference { get; set; }
        public string emi { get; set; }
        public string due_date { get; set; }
        public string amount { get; set; }
    }
}
