using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EPS.Models
{
    [Table("FUNC", Schema = "EPSMGR")]
    public class FUNC
    {
        [Key]
        [Required]
        public int SN { get; set; }
        [Required]
        [Display(Name = "功能編號")]
        public int FId { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name = "角色名稱")]
        public string FuncName { get; set; }
        [Display(Name = "父層功能編號")]
        public int PId { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Display(Name = "對應controller名稱")]
        public string Controller { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Display(Name = "對應action名稱")]
        public string Action { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(200)]
        [Display(Name = "對應URL")]
        public string Url { get; set; }
        [Display(Name = "顯示順序")]
        public int ShowOrder { get; set; }
        [Required]
        [Display(Name = "是否啟用")]
        public bool IsEnable { get; set; }
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