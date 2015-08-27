using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EPS.Models
{
    [Table("EPSUSER", Schema = "EPSMGR")]
    public class EPSUSER
    {
        [Key]
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        [Display(Name = "員工編號")]
        public string UId { get; set; }
        [Required]
        [StringLength(5)]
        [Display(Name = "員工姓名")]
        public string UserName { get; set; }
        [StringLength(200)]
        [Display(Name = "密碼")]
        public string UserPwd { get; set; }
        [StringLength(100)]
        [Column(TypeName = "varchar")]
        [Display(Name = "Email")]
        public string UserEmail { get; set; }
        //[ForeignKey("RId")]
        [Display(Name = "角色代碼")]
        public int RId { get; set; }
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
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        [Display(Name = "覆核者")]
        public string ReviewAccount { get; set; }
        [Display(Name = "覆核時間")]
        public DateTime? ReviewTime { get; set; }
    }
}