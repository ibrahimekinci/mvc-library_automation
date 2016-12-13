using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_Kutuphane.Models
{
    public class tbl_adres
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Adres Ad")]
        [Required(ErrorMessage = "Lütfen Adres adı alanını doldurunuz..")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Adres adı alanına 2 ile 25 arası karakter girilebilir...")]
        public string ad { get; set; }

        [Display(Name = "Adres Detay")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "Detay  alanına 2 ile 255 arası karakter girilebilir...")]
        public string detay { get; set; }

        public System.Nullable<int> sehirID { get; set; }

        public System.Nullable<int> ilceID { get; set; }

        public System.Nullable<int> mahallerID { get; set; }

        [Display(Name = "Kayıt Tarihi")]
        public System.DateTime kayitTarihi { get; set; }

        [Display(Name = "Güncelleme Tarihi")]
        public System.DateTime guncellemeTarihi { get; set; }

        [DefaultValue("true")]
        [Display(Name = "Durum")]
        public bool durum { get; set; }

        [Required]
        public int kullaniciID { get; set; }

        [ForeignKey("kullaniciID")]
        public virtual tbl_kullanici kullanici { get; set; }


    }
}