using System;
using System.ComponentModel.DataAnnotations;

namespace EPS.ViewModels.EPSROLE
{
    public class vEPSROLE
    {
        [Key]
        [Display(Name = "角色編號")]
        public int RId { get; set; }
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