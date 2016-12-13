using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_Kutuphane.Models
{
    public class tbl_kitapTur
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = ",Tür Ad")]
        [Required(ErrorMessage = "Lütfen Duyuru Tür alanını doldurunuz..")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Tür adı alanına 2 ile 25 arası karakter girilebilir...")]
        public string ad { get; set; }

        [Required]
        public int ustID { get; set; }
        public string iconHtml { get; set; }

        public string resimUrl { get; set; }


        [Display(Name = "Kayıt Tarihi")]
        [Required]
        public System.DateTime kayitTarihi { get; set; }
 
        [Required]
        public int ekleyenID { get; set; }

        [Display(Name = "Güncelleme Tarihi")]
        [Required]
        public System.DateTime guncellemeTarihi { get; set; }

        [Required]
        public int guncelleyenID { get; set; }

        [DefaultValue("true")]
        [Display(Name = "Durum")]
        public bool durum { get; set; }

        public virtual ICollection<tbl_kitap> kitap { get; set; }
    }
}