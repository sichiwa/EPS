using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EPS.Models
{
    [Table("ROLE", Schema = "EPSMGR")]
    public class EPSROLE
    {
        [Key]
        [Required]
        [Display(Name = "角色編號")]
        public int RId { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "角色名稱")]
        public string RoleName { get; set; }
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