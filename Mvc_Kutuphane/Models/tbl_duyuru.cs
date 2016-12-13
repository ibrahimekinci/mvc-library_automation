using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_Kutuphane.Models
{
    public class tbl_duyuru
    {
        [Key]
        //[Column(Order = 1)]
        public int ID { get; set; }

        [Display(Name = "Duyuru Ad")]
        [Required(ErrorMessage = "Lütfen Duyuru adı alanını doldurunuz..")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Duyuru adı alanına 2 ile 25 arası karakter girilebilir...")]
        public string ad { get; set; }

        [Display(Name = "Açıklama")]
        [Required(ErrorMessage = "Lütfen Açiklama alanını doldurunuz..")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "Açiklama  alanına 2 ile 255 arası karakter girilebilir...")]
        public string aciklama { get; set; }

        [Display(Name = "Detay")]
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
        public int ekleyenID { get; set; }
        [Required]
        public int guncelleyenID { get; set; }
    }
}