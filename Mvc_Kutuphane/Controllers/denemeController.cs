using Mvc_Kutuphane.Models;
using Mvc_Kutuphane.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Kutuphane.Controllers
{
    public class denemeController : Controller
    {
        db_Context db = new db_Context();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.sehir = new SelectList(db.sehir.OrderBy(x => x.ad).ToList(), "ID", "ad");
            ViewBag.ilce = new SelectList(db.ilce.Where(x=>x.sehirID==1).OrderBy(x => x.ad).ToList(), "ID", "ad");
            ViewBag.mahalle = new SelectList(db.mahalle.Where(x => x.ilce.sehir.ID == 1).OrderBy(x => x.ad).ToList(), "ID", "ad");
            return View();
        }
    }
}