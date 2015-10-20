using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPS.Models
{
    public class QuerySystmeLog
    {
        public int PageIndex { get; set; }
        public string nowUser { get; set; }
        public DateTime STime { get; set; }
        public DateTime ETime { get; set; }
        public string nowResult { get; set; }
    }
}