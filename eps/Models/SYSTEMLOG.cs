using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EPS.Models
{
    [Table("SYSTEMLOG", Schema = "EPSMGR")]
    public class SYSTEMLOG
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "唯一流水號")]
        public int SN { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        [Display(Name = "員工編號")]
        public string UId { get; set; }
        [StringLength(20)]
        [Display(Name = "處理模組名稱")]
        public string Controller { get; set; }
        [StringLength(100)]
        [Display(Name = "執行作業名稱")]
        public string Action { get; set; }
        [Required]
        [Display(Name = "起始時間")]
        public DateTime StartDateTime { get; set; }
        [Required]
        [Display(Name = "結束時間")]
        public DateTime EndDateTime { get; set; }
        [Display(Name = "處理總筆數")]
        public int TotalCount { get; set; }
        [Display(Name = "處理成功筆數")]
        public int SuccessCount { get; set; }
        [Display(Name = "處理失敗筆數")]
        public int FailCount { get; set; }
        [Required]
        [Display(Name = "處理結果")]
        public Boolean Result { get; set; }
        [Display(Name = "作業訊息")]
        public string Msg { get; set; }
    }
}