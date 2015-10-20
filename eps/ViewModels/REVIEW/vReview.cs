using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EPS.ViewModels.REVIEW
{
    public class vReview
    {
        [Key]
        [Display(Name = "日常檢核件編號")]
        public string CheckSN { get; set; }

        [Display(Name = "檢核日期")]
        public string CheckDate { get; set; }

        [Display(Name = "機房檢核主題名稱")]
        public string Title { get; set; }

        [Display(Name = "日常檢核覆核狀態")]
        public string CloseStutus { get; set; }

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
    }
}