using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPS.ViewModels.PROCESS
{
    public class vCHECKs
    {
        public string ShiftID { get; set; }
        public SelectList ShiftIDList { get; set; }
        public string HandoverItem { get; set; }
        public IEnumerable<vCHECKPROCESS> vCHECKPROCESS { get; set; }
    }
}