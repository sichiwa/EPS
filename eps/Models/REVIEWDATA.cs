using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EPS.Models
{
    [Table("REVIEWDATA", Schema = "EPSMGR")]
    public class REVIEWDATA
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ReviewSN { get; set; }
        [Required]
        [StringLength(8)]
        [Display(Name = "檢核日期")]
        public string CheckDate { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name = "日常檢核件編號")]
        public string CheckSN { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "機房檢核主題名稱")]
        public string ListName { get; set; }
        [Display(Name = "早班確認")]
        //[StringLength(200)]
        public bool ShiftOneChecked { get; set; }
        [Display(Name = "晚班確認")]
        //[StringLength(200)]
        public bool ShiftTrheeChecked { get; set; }
        [Display(Name = "假日班確認")]
        //[StringLength(200)]
        public bool ShiftFourChecked { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        [Display(Name = "建立者")]
        public string CreateAccount { get; set; }
        [Required]
        [Display(Name = "建立時間")]
        public DateTime? CreateTime { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        [Display(Name = "最後異動者")]
        public string UpadteAccount { get; set; }
        [Required]
        [Display(Name = "最後異動時間")]
        public DateTime? UpdateTime { get; set; }
    }
}