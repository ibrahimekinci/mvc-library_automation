using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_Kutuphane.Models
{
    public class tbl_kullanici
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen Kullanıcı adı alanını doldurunuz..")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Kullanıcı adı alanına 2 ile 25 arası karakter girilebilir...")]
        public string kadi { get; set; }

        public string resimUrl { get; set; }

        [Display(Name = "Tc Kimlik No")]
        [StringLength(11, MinimumLength = 2, ErrorMessage = "Tc Kimlik No alanına 11 karakter girilebilir...")]
        public string tckn { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen Şifre alanını doldurunuz..")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Şifre alanına 2 ile 25 arası karakter girilebilir...")]
        public string sifre { get; set; }

        [Display(Name = "Ad")]
        public string ad { get; set; }

        [Display(Name = "Soyad")]
        public string soyad { get; set; }

        [Display(Name = "Cinsiyet")]
        public Nullable<bool> cinsiyet { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> dogumTarihi { get; set; }

        public string cepTelefonu { get; set; }
        public string evTelefonu { get; set; }

        [Required(ErrorMessage = "Lütfen eposta alanını doldurunuz..")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Lütfen doğru bir eposta  giriniz..")]
        [Display(Name = "E-Posta")]
        public string eposta { get; set; }

        [Required]
        public int rolID { get; set; }

        [ForeignKey("rolID")]
        public virtual tbl_rol rol { get; set; }

        [Display(Name = "Kayıt Tarihi")]
        [Required]
        public System.DateTime kayitTarihi { get; set; }

        [DefaultValue("true")]
        [Display(Name = "Durum")]
        public bool durum { get; set; }

        public virtual ICollection<tbl_adres> adres { get; set; }
        public virtual ICollection<tbl_kitapHaraket> kitapHaraket { get; set; }
        public virtual ICollection<tbl_kitapSepet> kitapSepet { get; set; }
      
    }
}