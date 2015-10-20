using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace EPS.Models
{
    [Table("REJECTPROFILE", Schema = "EPSMGR")]
    public class REJECTPROFILE
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "唯一流水號")]
        public int SN { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(10)]
        [Display(Name = "日常檢核覆核狀態")]
        public string CloseStauts { get; set; }
        [Required]
        [Display(Name = "下一位覆核角色ID")]
        public string NextReviews { get; set; }
        [Required]
        [StringLength(3)]
        [Display(Name = "使用的郵件範本ID")]
        public string MailTempID { get; set; }
        [Required]
        [StringLength(6)]
        [Display(Name = "建立者")]
        public string CreateAccount { get; set; }
        [Required]
        [Display(Name = "建立時間")]
        public DateTime? CreateTime { get; set; }
        [Required]
        [StringLength(6)]
        [Display(Name = "最後異動者")]
        public string UpadteAccount { get; set; }
        [Required]
        [Display(Name = "最後異動時間")]
        public DateTime? UpdateTime { get; set; }
    }
}