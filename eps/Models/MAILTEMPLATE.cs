using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EPS.Models
{
    [Table("MAILTEMPLATE", Schema = "EPSMGR")]
    public class MAILTEMPLATE
    {
        [Key]
        [Required]
        [StringLength(3)]
        [Display(Name = "範本ID")]
        public string MailTempID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "範本名稱")]
        public string TemplateName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "範本主旨")]
        public string Subject { get; set; }
        [Required]
        [Display(Name = "範本內文")]
        public string Body { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Display(Name = "寄件者")]
        public string Sender { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(1000)]
        [Display(Name = "收件者")]
        public string Receiver { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(1000)]
        [Display(Name = "副本收件者")]
        public string CC { get; set; }
        [Required]
        [Display(Name = "使用HTML編碼")]
        public bool IsHTML { get; set; }
        [Required]
        [Display(Name = "使用SSL")]
        public bool IsSSL { get; set; }
        [Required]
        [Display(Name = "郵件伺服器ID")]
        public int MailServerID { get; set; }
        [Required]
        [Display(Name = "寄件優先權")]
        public int Priority { get; set; }
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