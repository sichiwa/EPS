using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPS.Models;

namespace EPS.ViewModels.LOG
{
    public class vSystemLog
    {
        public  int PageIndex { get; set; }
        public string nowUser { get; set; }
        public string nowResult { get; set; }
        public DateTime STime { get; set; }
        public DateTime ETime { get; set; }
        public SelectList UserList { get; set; }
        public List<SelectListItem> ResultList { get; set; }
        public QuerySystmeLog qSL { get; set; }
        public PagedList.IPagedList<SYSTEMLOG> SYSTEMLOGList { get; set; }
    }
}