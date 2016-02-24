using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EPS.Models
{
    [Table("CHECKLIST", Schema = "EPSMGR")]   
    public class CHECKLIST
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "檢核項目ID")]
        public int ListID { get; set; }
        //[ForeignKey("CheckID")]

        [Required]
        [Display(Name = "機房檢核文件ID")]
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
        [Column(TypeName = "varchar")]
        [Display(Name = "檢核開始時間")]
        public string StartTime { get; set; }
        [Required]
        [StringLength(20)]
        [Column(TypeName = "varchar")]
        [Display(Name = "檢核結束時間")]
        public string EndTime { get; set; }
        [Required]
        [Display(Name = "檢核班別代號")]
        [StringLength(2)]
        [Column(TypeName = "char")]
        public string ShiftID { get; set; } 
        [StringLength(20)]
        [Display(Name = "檢核類別代號")]
        public string ClassID { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name = "檢核類型")]
        public string CheckType { get; set; }
        [Required]
        [Display(Name = "持續顯示")]
        public bool AlwaysShow { get; set; }
        [StringLength(6)]
        [Display(Name = "負責人")]
        [Column(TypeName = "varchar")]
        public string ChargerID { get; set; }
        [Required]
        [Display(Name = "顯示順序")]
        public int ShowOrder { get; set; }
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