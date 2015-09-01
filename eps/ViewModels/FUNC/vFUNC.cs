using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EPS.ViewModels.FUNC
{
    public class vFUNC
    {
        [Key]
        public int SN { get; set; }
        [Display(Name = "功能編號")]
        public int FId { get; set; }
        [Display(Name = "角色名稱")]
        public string FuncName { get; set; }
        [Display(Name = "父層功能編號")]
        public int PId { get; set; }
        [Display(Name = "對應controller名稱")]
        public string Controller { get; set; }
        [Display(Name = "對應action名稱")]
        public string Action { get; set; }
        [Display(Name = "對應URL")]
        public string Url { get; set; }
        [Display(Name = "顯示順序")]
        public int ShowOrder { get; set; }
        [Display(Name = "是否啟用")]
        public bool IsEnable { get; set; }
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