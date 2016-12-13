using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_Kutuphane.Models
{
    public class tbl_ilce
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public int sehirID { get; set; }
        [Display(Name = "AD")]
        public string ad { get; set; }
        public virtual ICollection<tbl_mahalle> mahalle { get; set; }
        public virtual tbl_sehir sehir { get; set; }
    }
}