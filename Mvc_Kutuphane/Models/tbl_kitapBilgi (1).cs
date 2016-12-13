using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_Kutuphane.Models
{
    public class tbl_kitapBilgi
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = ",Kitap Bilgi Ad")]
        [Required(ErrorMessage = "Lütfen Kitap Bilgi adı alanını doldurunuz..")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Kitap Bilgi adı alanına 2 ile 25 arası karakter girilebilir...")]
        public string ad { get; set; }

        [Display(Name = "Açıklama")]
        [Required(ErrorMessage = "Lütfen Açiklama alanını doldurunuz..")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "Açiklama  alanına 2 ile 255 arası karakter girilebilir...")]
        public string aciklama { get; set; }

        [Display(Name = "Kayıt Tarihi")]
        [Required]
        public System.DateTime kayitTarihi { get; set; }

        [Required]
        public int kitapID { get; set; }
        [ForeignKey("kitapID")]
        public virtual tbl_kitap kitap { get; set; }

        [Required]
        public int ekleyenID { get; set; }

        [Display(Name = "Güncelleme Tarihi")]
        [Required]
        public System.DateTime guncellemeTarihi { get; set; }

        [Required]
        public int guncelleyenID { get; set; }
    }
}