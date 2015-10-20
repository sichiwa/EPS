using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EPS.ViewModels.PROCESS
{
    public class vCHECKPROCESS
    {
        [Key]
        [Display(Name = "日常檢核件編號")]
        public string CheckSN { get; set; }
        [Display(Name = "機房檢核文件ID")]
        public int CheckID { get; set; }
        [Display(Name = "檢核件日期")]
        public string CheckDate { get; set; }
        [Display(Name = "機房檢核主題名稱")]
        public string Title { get; set; }
        [Display(Name = "簽章種類")]
        public string SignType { set; get; }
        public IEnumerable<vCHECKDETAIL> vCHECKDETAILs { get; set; }
    }
}