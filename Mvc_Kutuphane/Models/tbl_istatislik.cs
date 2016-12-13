using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_Kutuphane.Models
{
    public class tbl_istatislik
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = ",İstatislik Ad")]
        [Required(ErrorMessage = "Lütfen İstatislik adı alanını doldurunuz..")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "İstatislik adı alanına 2 ile 25 arası karakter girilebilir...")]
        public string ad { get; set; }

        [Display(Name = "İstatislik Detay")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Detay  alanına 2 ile 255 arası karakter girilebilir...")]
        public string detay { get; set; }

        public string resimUrl { get; set; }

        [Display(Name = "Kayıt Tarihi")]
        [Required]
        public System.DateTime kayitTarihi { get; set; }

        [Display(Name = "Bitiş Tarihi")]
        [Required]
        public DateTime bitisTarihi { get; set; }

        [Display(Name = "Güncelleme Tarihi")]
        [Required]
        public System.DateTime guncellemeTarihi { get; set; }

        [DefaultValue("true")]
        [Display(Name = "Durum")]
        public bool durum { get; set; }

        [Required]
        public int guncelleyenID { get; set; }

        [Required]
        public int ekleyenID { get; set; }
    }
}