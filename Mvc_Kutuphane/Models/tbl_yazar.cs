using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_Kutuphane.Models
{
    public class tbl_yazar
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = ",Yazar Ad")]
        [Required(ErrorMessage = "Lütfen Yazar adı alanını doldurunuz..")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Yazar adı alanına 2 ile 25 arası karakter girilebilir...")]
        public string ad { get; set; }

        [Display(Name = ",Yazar Soyad")]
        [Required(ErrorMessage = "Lütfen Soyad adı alanını doldurunuz..")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Soyad alanına 2 ile 25 arası karakter girilebilir...")]
        public string soyad { get; set; }
        public Nullable<System.DateTime> dogumTarihi { get; set; }

        [Display(Name = "Kayıt Tarihi")]
        [Required]
        public System.DateTime kayitTarihi { get; set; }

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
        public virtual ICollection<tbl_kitap> kitap { get; set; }
    }
}