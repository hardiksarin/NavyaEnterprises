using System;
using System.Collections.Generic;
using System.Text;

namespace GravitonLibrary.Models
{
    public class CostCenterModel
    {
        public int cost_center_id { get; set; }
        public string cc_name { get; set; }
        public string cc_alias { get; set; }
        public int under_category { get; set; }
        public int under_cc { get; set; }
    }
}
