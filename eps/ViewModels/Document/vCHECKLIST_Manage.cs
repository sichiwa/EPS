using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace EPS.ViewModels.Document
{
    public class vCHECKLIST_Manage
    {
        public List<vCHECKLIST> vCHECKLISTs { get; set; }

        public sealed class vCHECKLIST
        {
            [Key]
            [Required]
            [Display(Name = "唯一流水號")]
            public int SN { get; set; }
            [Required]
            public int CheckID { get; set; }
            [Required]
            [StringLength(200)]
            [Display(Name = "機房檢核主題名稱")]
            public string ListName { get; set; }
            [StringLength(1000)]
            [Display(Name = "機房檢核項目敘述")]
            public string Definition { get; set; }
            [Required]
            [StringLength(20)]
            [Display(Name = "檢核開始時間")]
            public string StartTime { get; set; }
            [Required]
            [StringLength(20)]
            [Display(Name = "檢核結束時間")]
            public string EndTime { get; set; }
            [Required]
            [StringLength(2)]
            public string ShiftID { get; set; }
            [Display(Name = "檢核班別")]
            public SelectList ShiftIDList { get; set; }
            [StringLength(20)]
            public string ClassID { get; set; }
            [Display(Name = "檢核類別")]
            public SelectList ClassIDList { get; set; }
            [Required]
            [StringLength(10)]
            [Display(Name = "檢核類型")]
            public string CheckType { get; set; }
            [Required]
            [Display(Name = "持續顯示")]
            public bool AlwaysShow { get; set; }
            [StringLength(6)]
            public string ChargerID { get; set; }
            [Display(Name = "負責人")]
            public SelectList ChargerList { get; set; }
            [Required]
            [Display(Name = "顯示順序")]
            public int ShowOrder { get; set; }
        }
    }
}