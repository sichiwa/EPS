using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EPS.Models
{
    [Table("CHECKPROCESS", Schema = "EPSMGR")]
    public class CHECKPROCESS
    {
        [Key]
        [Required]
        [StringLength(10)]
        [Display(Name = "日常檢核件編號")]
        public string CheckSN { get; set; }
        //[ForeignKey("CheckID")]
        [Required]
        [Display(Name = "機房檢核項目ID")]
        public int CheckID { get; set; }
        [StringLength(1000)]
        [Display(Name = "日常檢核備註")]
        public string Notes { get; set; }
        [Display(Name = "日常檢核附件")]
        public string Attachment { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name = "日常檢核覆核狀態")]
        public string CloseStutus { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        [Display(Name = "目前覆核人")]
        public string CrrentStatus { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        [Display(Name = "下一位覆核人")]
        public string NextReview { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        [Display(Name = "最終覆核人")]
        public string FinalReview { get; set; }
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