using System;
using System.Collections.Generic;
using System.Text;

namespace GravitonLibrary.Models
{
    public class CostCategoryModel
    {
        public int category_id { get; set; }
        public string category_name { get; set; }
        public string category_alias { get; set; }
        public bool revenue { get; set; }
    }
}
