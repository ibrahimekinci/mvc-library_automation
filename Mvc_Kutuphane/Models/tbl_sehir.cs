using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_Kutuphane.Models
{
    public class tbl_sehir
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Display(Name = "AD")]
        public string plaka { get; set; }
        public string ad { get; set; }
        public virtual ICollection<tbl_ilce> ilce { get; set; }
    }
}