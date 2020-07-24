using System;
using System.Collections.Generic;
using System.Text;

namespace GravitonLibrary.Models
{
    public class MailingDetailsModel
    {
        public string md_name { get; set; }
        public string md_address { get; set; }
        public string md_city { get; set; }
        public string md_state { get; set; }
        public string md_country { get; set; }
        public string md_pincode { get; set; }
        public int lid { get; set; }
    }
}
