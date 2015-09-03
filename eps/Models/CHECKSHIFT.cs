using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPS.Models
{
    [Table("CHECKSHIFT", Schema = "EPSMGR")]
    public class CHECKSHIFT
    {
        [Key]
        [Required]
        [Column(TypeName = "char")]
        [StringLength(2)]
        [Display(Name = "班別ID")]
        public string ShiftID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "班別說明")]
        public string ShiftValue { get; set; }
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