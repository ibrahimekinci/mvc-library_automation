using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_Kutuphane.Models
{
    public class sifreDegistir
    {
        //[NotMapped]//Veritabanına eklenmesini engeller
        [Display(Name = "Şifre")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "sifre alanına 2 ile 25 arası karakter girilebilir...")]
        [Required(ErrorMessage = "Lütfen Şifre alanını doldurunuz..")]
        [DataType(DataType.Password)]
        public string sifre { get; set; }



        [Required(ErrorMessage = "Lütfen Şifre alanını doldurunuz..")]
        [Display(Name = "Yeni Şifre")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Yeni Şifre alanına 2 ile 25 arası karakter girilebilir...")]
        [DataType(DataType.Password)]
        public string yeniSifre{ get; set; }


        [Required(ErrorMessage = "Yeni Şifre Tekrar  alanını doldurunuz..")]
        [Display(Name = "Yeni Şifre Tekrar")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Yeni Şifre Tekrar alanına 2 ile 25 arası karakter girilebilir...")]
        [Compare("yeniSifre", ErrorMessage = "İki şifre eşleşmiyor!")]
        [DataType(DataType.Password)]
        public string yeniSifreTekrar { get; set; }
    }
}