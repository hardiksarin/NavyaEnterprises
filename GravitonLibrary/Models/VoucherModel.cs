using System;
using System.Collections.Generic;
using System.Text;

namespace GravitonLibrary.Models
{
    public class VoucherModel
    {
        public int vid { get; set; }
        public string v_date { get; set; }
        public int v_number { get; set; }
        public string vtype { get; set; }
        public int account { get; set; }
        public ParticularModel Particular { get; set; }
    }
}
