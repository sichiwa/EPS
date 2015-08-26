using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EPS.Models
{
    [Table("CHECKCLASS", Schema = "EPSMGR")]
    public class CHECKCLASS
    {
        [Key]
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(10)]
        [Display(Name = "類別ID")]
        public string ClassID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "類別說明")]
        public string ClassValue { get; set; }
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