using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EPS.ViewModels.Document
{
    public class vCHECKLIST
    {
        [Key]
        [Display(Name = "唯一流水號")]
        public int ListID { get; set; }
        public int CheckID { get; set; }
        [Display(Name = "機房檢核主題名稱")]
        public string ListName { get; set; }
        [Display(Name = "機房檢核項目敘述")]
        public string Definition { get; set; }
        [Display(Name = "檢核開始時間")]
        public string StartTime { get; set; }
        [Display(Name = "檢核結束時間")]
        public string EndTime { get; set; }
        [Display(Name = "檢核班別")]
        public string ShiftName { get; set; }
        [Display(Name = "檢核分類")]
        public string ClassName { get; set; }
        [Display(Name = "檢核類型")]
        public string CheckType { get; set; }
        [Display(Name = "持續顯示")]
        public bool AlwaysShow { get; set; }
        [Display(Name = "負責人")]
        public string Charger { get; set; }
        [Display(Name = "顯示順序")]
        public int ShowOrder { get; set; }
        [Display(Name = "建立者")]
        public string CreateAccount { get; set; }
        [Display(Name = "建立時間")]
        public DateTime? CreateTime { get; set; }
        [Display(Name = "最後異動者")]
        public string UpadteAccount { get; set; }
        [Display(Name = "最後異動時間")]
        public DateTime? UpdateTime { get; set; }
    }
}