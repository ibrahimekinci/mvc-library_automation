using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_Kutuphane.Models
{
    public class tbl_kitap
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = ",Kitap Ad")]
        [Required(ErrorMessage = "Lütfen Kitap adı alanını doldurunuz..")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Kitap adı alanına 2 ile 25 arası karakter girilebilir...")]
        public string ad { get; set; }

        [Display(Name = "Kitap Detay")]
        [Required(ErrorMessage = "Lütfen Kitap detay alanını doldurunuz..")]
        [StringLength(255, MinimumLength = 0, ErrorMessage = "Kitap  alanına 2 ile 255 arası karakter girilebilir...")]
        public string detay { get; set; }

        public string resimUrl { get; set; }

        [Display(Name = "İade Tarihi")]
        [Required]
        public DateTime iadeTarihi { get; set; }

        [Required]
        [Display(Name = "Kayıt Tarihi")]
        public System.DateTime kayitTarihi { get; set; }

        [Required]
        public int ekleyenID { get; set; }

        [Required]
        [Display(Name = "Güncelleme Tarihi")]
        public System.DateTime guncellemeTarihi { get; set; }

        [Required]
        public int guncelleyenID { get; set; }

        [DefaultValue("true")]
        [Display(Name = "Durum")]
        public bool durum { get; set; }

        [Required(ErrorMessage = "Lütfen Kitap Türü Seçiniz..")]
        public int kitapTurID { get; set; }

        [ForeignKey("kitapTurID")]
        public virtual tbl_kitapTur kitapTur { get; set; }

        [Required(ErrorMessage = "Lütfen Kitap Türü Seçiniz..")]
        public int yazarID { get; set; }

        [ForeignKey("yazarID")]
        public virtual tbl_yazar yazar { get; set; }

        [Required(ErrorMessage = "Lütfen Kitap Türü Seçiniz..")]
        public int yayinEviID { get; set; }

        [ForeignKey("yayinEviID")]
        public virtual tbl_yayinEvi yayinEvi { get; set; }

        
        public virtual ICollection<tbl_kitapBilgi> kitap { get; set; }
        public virtual ICollection<tbl_kitapHaraket> kitapHaraket { get; set; }
        public virtual ICollection<tbl_kitapSepet> kitapSepet { get; set; }
    }
}