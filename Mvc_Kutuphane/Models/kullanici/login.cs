using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_Kutuphane.Models
{
    public class login
    {
        [Display(Name = "Kullanıcı adı")]
        [Required(ErrorMessage = "Lütfen Kullanıcı adı alanını doldurunuz..")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Kullanıcı adı alanına 2 ile 25 arası karakter girilebilir...")]
        public string kadi { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen Şifre alanını doldurunuz..")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Şifre alanına 2 ile 25 arası karakter girilebilir...")]
        public string sifre { get; set; }

    }
}