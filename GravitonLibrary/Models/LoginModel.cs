using System;
using System.Collections.Generic;
using System.Text;

namespace GravitonLibrary.Models
{
    public class LoginModel
    {
        public int login_id { get; set; }
        public string name { get; set; }
        public string email_id { get; set; }
        public string password { get; set; }
        public string access { get; set; }
    }
}
