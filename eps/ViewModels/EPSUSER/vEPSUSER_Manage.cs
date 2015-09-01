using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EPS.ViewModels.EPSUSER
{
    public class vEPSUSER_Manage
    {
        [Key]
        [Required(ErrorMessage = "請輸入員工編號")]
        [StringLength(6)]
        [Display(Name = "員工編號")]
        public string UId { get; set; }
        [Required(ErrorMessage = "請輸入員工姓名")]
        [StringLength(5)]
        [Display(Name = "員工姓名")]
        public string UserName { get; set; }
        [StringLength(200)]
        [Display(Name = "密碼")]
        public string UserPwd { get; set; }
        [StringLength(100)]
        [Display(Name = "Email")]
        public string UserEmail { get; set; }
        public int RId { get; set; }
        [Display(Name = "角色")]
        public SelectList Role { get; set; } 
    }
}