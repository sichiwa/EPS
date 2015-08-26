using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EPS.Models
{
    [Table("REVIEWPROFILE", Schema = "EPSMGR")]
    public class REVIEWPROFILE
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "唯一流水號")]
        public int SN { get; set; }
        //[ForeignKey("CheckID")]
        [Required]
        [Display(Name = "機房檢核項目ID")]
        public int CheckID { get; set; }
        [StringLength(6)]
        [Display(Name = "最終覆核人")]
        public string FinalReview { get; set; }
        [StringLength(1000)]
        [Display(Name = "敘述備註")]
        public string Definition { get; set; }
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