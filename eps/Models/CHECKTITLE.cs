using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EPS.Models
{
    [Table("CHECKTITLE", Schema = "EPSMGR")]
    public class CHECKTITLE
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "機房檢核項目ID")]
        public int CheckID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "機房檢核主題名稱")]
        public string Title { get; set; }
        [StringLength(500)]
        [Display(Name = "機房檢核主題描述")]
        public string Definition { get; set; }
        [Display(Name = "機房檢核主題附件")]
        public string Attachment { get; set; }
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