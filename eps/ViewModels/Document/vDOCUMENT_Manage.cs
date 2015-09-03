using System;
using System.ComponentModel.DataAnnotations;

namespace EPS.ViewModels.Document
{
    public class vDOCUMENT_Manage
    {
        [Key]
        [Required]
        [Display(Name = "機房檢核項目ID")]
        public int CheckID { get; set; }
        [Required(ErrorMessage = "請填入主題名稱")]
        [StringLength(50)]
        [Display(Name = "機房檢核主題名稱")]
        public string Title { get; set; }
        [StringLength(500)]
        [Display(Name = "機房檢核主題描述")]
        public string Definition { get; set; }
        [Display(Name = "機房檢核主題附件")]
        public string Attachment { get; set; }
    }
}