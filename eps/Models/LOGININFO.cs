using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EPS.Models
{
    public class LoginInfo
    {
        [Display(Name = "帳號")]
        [StringLength(6)]
        [Required]
        public string UserID { get; set; }
        [Display(Name = "密碼")]
        [Required]
        public string Pwd { get; set; }
        //[Display(Name = "憑證登入")]
        //public bool UseCertLogin { get; set; }
        //public string Plaintext { get; set; }
        //public string SignData { get; set; }
    }
}