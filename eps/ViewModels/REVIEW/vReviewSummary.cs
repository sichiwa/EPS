using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EPS.Models;

namespace EPS.ViewModels.REVIEW
{
    public class vReviewSummary
    {
        [Key]
        [Display(Name = "檢核日期")]
        public string CheckDate { get; set; }
        [Display(Name = "事件描述及行動")]
        public string EventItem { get; set; }
        [Display(Name = "交接事項")]
        public string HandoverItem { get; set; }
        [Display(Name = "早班")]
        public string ShiftOne { get; set; }
        [Display(Name = "晚班")]
        public string ShiftThree { get; set; }
        [Display(Name = "假日班")]
        public string ShiftFour { get; set; }
        [Display(Name = "領班")]
        public string ShiftTop { get; set; }
        [Display(Name = "主管人員")]
        public string ManageOne { get; set; }
        [Display(Name = "系統部主管")]
        public string ManageTop { get; set; }
        public IEnumerable <REVIEWDATA> RD { get; set; }
    }
}