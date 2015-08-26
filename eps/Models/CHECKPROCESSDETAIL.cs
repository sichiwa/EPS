using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EPS.Models
{
    [Table("CHECKPROCESSDETAIL", Schema = "EPSMGR")]
    public class CHECKPROCESSDETAIL
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "唯一流水號")]
        public int SN { get; set; }
        //[ForeignKey("CheckSN")]
        [Required]
        [Column(TypeName = "char")]
        [StringLength(10)]
        [Display(Name = "日常檢核件編號")]
        public string CheckSN { get; set; }
        //[ForeignKey("CheckID")]
        [Required]
        [Display(Name = "機房檢核項目ID")]
        public int CheckID { get; set; }
        [Required]
        [Display(Name = "檢核開始時間")]
        public DateTime StartDateTime { get; set; }
        [Required]
        [Display(Name = "檢核結束時間")]
        public DateTime EndDateTime { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "檢核結果")]
        public string CheckResult { get; set; }
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