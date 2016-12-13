using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_Kutuphane.Models
{
    public class tbl_kitapSepet
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Kayıt Tarihi")]
        [Required]
        public System.DateTime kayitTarihi { get; set; }

        public int kitapID { get; set; }
        
        [ForeignKey("kitapID")]
        public virtual tbl_kitap kitap { get; set; }


        [Required]
        public int kullaniciID { get; set; }

        [ForeignKey("kullaniciID")]
        public virtual tbl_kullanici kullanici { get; set; }
       
    }
}