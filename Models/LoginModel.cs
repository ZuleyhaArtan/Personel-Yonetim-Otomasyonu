using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace deneme2.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Lütfen mail adresinizi giriniz.")]
        [Display(Name = "E-Mail")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}