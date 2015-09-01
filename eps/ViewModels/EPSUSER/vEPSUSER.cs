using System;
using System.ComponentModel.DataAnnotations;

namespace EPS.ViewModels.EPSUSER
{
    public class vEPSUSER
    {
        [Key]
        [Display(Name = "員工編號")]
        public string UId { get; set; }
        [Display(Name = "員工姓名")]
        public string UserName { get; set; }
        [Display(Name = "Email")]
        public string UserEmail { get; set; }
        [Display(Name = "角色名稱")]
        public string RoleName { get; set; }
        [Display(Name = "建立者")]
        public string CreateAccount { get; set; }
        [Display(Name = "建立時間")]
        public DateTime? CreateTime { get; set; }
        [Display(Name = "最後異動者")]
        public string UpadteAccount { get; set; }
        [Display(Name = "最後異動時間")]
        public DateTime? UpdateTime { get; set; }
    }
}