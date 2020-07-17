using System;
using System.Collections.Generic;
using System.Text;

namespace GravitonLibrary.Models
{
    public class GroupModel
    {
        public int group_id { get; set; }
        public string group_name { get; set; }
        public string group_alias { get; set; }
        public int under_group { get; set; }
    }
}
