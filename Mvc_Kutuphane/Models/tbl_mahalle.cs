using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_Kutuphane.Models
{
    public class tbl_mahalle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public int ilceID { get; set; }

        [Display(Name = "AD")]
        public string ad { get; set; }

        public virtual tbl_ilce ilce { get; set; }
    }
}