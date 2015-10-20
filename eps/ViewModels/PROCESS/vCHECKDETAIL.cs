using System;
using System.ComponentModel.DataAnnotations;

namespace EPS.ViewModels.PROCESS
{
    public class vCHECKDETAIL
    {

        [Key]
        [Display(Name = "檢核項目ID")]
        public int ListID { get; set; }

        [Display(Name = "機房檢核文件ID")]
        public int CheckID { get; set; }

        //[Display(Name = "機房檢核主題名稱")]
        //public string Title { get; set; }

        [Display(Name = "檢核開始時間")]
        public string StartTime { get; set; }
       
        [Display(Name = "檢核結束時間")]
        public string EndTime { get; set; }

        [Display(Name = "機房檢核主題名稱")]
        public string ListName { get; set; }

        [Display(Name = "檢核類型")]
        public string CheckType { get; set; }

        [Display(Name = "檢核班別")]
        public string Shift { get; set; }

        [Display(Name = "檢核結果")]
        public string CheckResult { get; set; }

        [Display(Name = "檢核件狀態")]
        public string CloseStatus { get; set; }


    }
}