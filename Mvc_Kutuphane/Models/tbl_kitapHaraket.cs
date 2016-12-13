using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_Kutuphane.Models
{
    public class tbl_kitapHaraket
    {
        [Key]
        public int ID { get; set; }
        [Required]
       
        public System.DateTime kayitTarihi { get; set; }

        [Display(Name = "Bitiş Tarihi")]
        [Required]
        public DateTime bitisTarihi { get; set; }

        public int kitapID { get; set; }
        public virtual tbl_kitap kitap { get; set; }

        [Required]
        public int kullaniciID { get; set; }
        [Required]
        public virtual tbl_kullanici kullanici { get; set; }
       

    }
}