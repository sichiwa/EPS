using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EPS.Models
{
    [Table("REJECTREASON", Schema = "EPSMGR")]
    public class REJECTREASON
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "流水號")]
        public int SN { get; set; }
        [StringLength(10)]
        [Display(Name = "日常檢核件編號")]
        public string CheckSN { get; set; }
        [StringLength(50)]
        [Column(TypeName = "nvarchar")]
        [Display(Name = "駁回理由")]
        public string Reason { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        [Display(Name = "建立者")]
        public string CreateAccount { get; set; }
        [Required]
        [Display(Name = "建立時間")]
        public DateTime? CreateTime { get; set; }
    }
}