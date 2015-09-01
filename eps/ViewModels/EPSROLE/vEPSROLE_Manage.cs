using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using EPS.Models;

namespace EPS.ViewModels.EPSROLE
{
    public class vEPSROLE_Manage
    {
        [Key]
        [Required]
        [Display(Name = "角色編號")]
        public int RId { get; set; }
        [Required(ErrorMessage = "請填入角色名稱")]
        [StringLength(20)]
        [Display(Name = "角色名稱")]
        public string RoleName { get; set; }
        [Display(Name = "功能")]
        [Required(ErrorMessage = "請至少選擇一項功能")]
        public int[] FuncList { get; set; }
        [Display(Name = "功能")]
        public SelectList Funcs { get; set; }
    }
}