using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EPS.ViewModels.FUNC
{
    public class vFUNC_Manage
    {
        [Key]
        [Required]
        public int SN { get; set; }
        [Required(ErrorMessage = "請填入功能名稱")]
        [Display(Name = "功能編號")]
        public int FId { get; set; }
        [Required(ErrorMessage = "請填入功能名稱")]
        [StringLength(20)]
        [Display(Name = "功能名稱")]
        public string FuncName { get; set; }
        [Display(Name = "父層功能編號")]
        public int PId { get; set; }
        [StringLength(50)]
        [Display(Name = "對應controller名稱")]
        public string Controller { get; set; }
        [StringLength(50)]
        [Display(Name = "對應action名稱")]
        public string Action { get; set; }
        [StringLength(200)]
        [Display(Name = "對應URL")]
        public string Url { get; set; }
        [Display(Name = "顯示順序")]
        public int ShowOrder { get; set; }
        [Required(ErrorMessage = "請勾選是否啟用")]
        [Display(Name = "是否啟用")]
        public bool IsEnable { get; set; }
    }
}