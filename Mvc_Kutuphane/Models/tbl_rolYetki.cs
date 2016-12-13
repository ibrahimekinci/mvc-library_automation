using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_Kutuphane.Models
{
    public class tbl_rolYetki
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Lütfen gerekli alanları doldurunuz")]
        [Display(Name = "ekle")]
        public bool add { get; set; }
        [Required(ErrorMessage = "Lütfen gerekli alanları doldurunuz")]
        [Display(Name = "sil")]
        public bool delete { get; set; }
        [Required(ErrorMessage = "Lütfen gerekli alanları doldurunuz")]
        [Display(Name = "Güncelle")]
        public bool update { get; set; }

        [Display(Name = "Kayıt Tarihi")]
        [Required]
        public System.DateTime kayitTarihi { get; set; }

        [Display(Name = "Güncelleme Tarihi")]
        [Required]
        public System.DateTime guncellemeTarihi { get; set; }

        [DefaultValue("true")]
        [Display(Name = "Durum")]
        public bool durum { get; set; }

        public int rolID { get; set; }

        [ForeignKey("rolID")]
        public virtual tbl_rol rol { get; set; }
        public int rolYetkiListeID { get; set; }

        [ForeignKey("rolYetkiListeID")]
        public virtual tbl_rolYetkiListe rolYetkiListe { get; set; }

        [Required]
        public int ekleyenID { get; set; }
        [Required]
        public int guncelleyenID { get; set; }

   
    }
}