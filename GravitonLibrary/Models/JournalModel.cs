using System;
using System.Collections.Generic;
using System.Text;

namespace GravitonLibrary.Models
{
    public class JournalModel
    {
        /// <summary>
        /// Journal Date
        /// </summary>
        public string j_date { get; set; }
        /// <summary>
        /// Journal Time
        /// </summary>
        public string j_time { get; set; }
        /// <summary>
        /// Journal String.
        /// </summary>
        public string j_log { get; set; }
    }
}