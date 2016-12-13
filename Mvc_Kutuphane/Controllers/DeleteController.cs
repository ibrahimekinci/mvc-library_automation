using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvc_Kutuphane.DAL;
using Mvc_Kutuphane.Models;

namespace Mvc_Kutuphane.Controllers.Admin
{
    public class DeleteController : Controller
    {
        private db_Context db = new db_Context();

        public ActionResult Index()
        {
            return RedirectToAction("Kitap");
        }





        public ActionResult Rol()
        {
            return View(db.rol.ToList());
        }

       
        public ActionResult DelRol(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_rol tbl_rol = db.rol.Find(id);
            if (tbl_rol == null)
            {
                return HttpNotFound();
            }
            return View(tbl_rol);
        }

        [HttpPost, ActionName("DelRol")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed7(int id)
        {
            tbl_rol tbl_rol = db.rol.Find(id);
            db.rol.Remove(tbl_rol);
            db.SaveChanges();
            return RedirectToAction("Rol");
        }







        public ActionResult Kitap()
        {
            var kitap = db.kitap.Include(t => t.kitapTur).Include(t => t.yayinEvi).Include(t => t.yazar);
            return View(kitap.ToList());
        }
        public ActionResult DelKitap(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_kitap tbl_kitap = db.kitap.Find(id);
            if (tbl_kitap == null)
            {
                return HttpNotFound();
            }
            return View(tbl_kitap);
        }

        [HttpPost, ActionName("DelKitap")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed3(int id)
        {
            tbl_kitap tbl_kitap = db.kitap.Find(id);
            db.kitap.Remove(tbl_kitap);
            db.SaveChanges();
            return RedirectToAction("Kitap");
        }














        public ActionResult Yazar()
        {
            return View(db.yazar.ToList());
        }
        public ActionResult DelYazar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_yazar tbl_yazar = db.yazar.Find(id);
            if (tbl_yazar == null)
            {
                return HttpNotFound();
            }
            return View(tbl_yazar);
        }
        [HttpPost, ActionName("DelYazar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_yazar tbl_yazar = db.yazar.Find(id);
            db.yazar.Remove(tbl_yazar);
            db.SaveChanges();
            return RedirectToAction("Yazar");
        }








        public ActionResult KitapTur()
        {
            return View(db.kitapTur.ToList());
        }
        public ActionResult DelKitapTur(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_kitapTur tbl_kitapTur = db.kitapTur.Find(id);
            if (tbl_kitapTur == null)
            {
                return HttpNotFound();
            }
            return View(tbl_kitapTur);
        }
        [HttpPost, ActionName("DelKitapTur")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed2(int id)
        {
            tbl_kitapTur tbl_kitapTur = db.kitapTur.Find(id);
            db.kitapTur.Remove(tbl_kitapTur);
            db.SaveChanges();
            return RedirectToAction("KitapTur");
        }









        public ActionResult Yayinevi()
        {
            return View(db.yayinEvi.ToList());
        }
        public ActionResult DElYayinevi(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_yayinEvi tbl_yayinEvi = db.yayinEvi.Find(id);
            if (tbl_yayinEvi == null)
            {
                return HttpNotFound();
            }
            return View(tbl_yayinEvi);
        }
        [HttpPost, ActionName("DElYayinevi")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed1(int id)
        {
            tbl_yayinEvi tbl_yayinEvi = db.yayinEvi.Find(id);
            db.yayinEvi.Remove(tbl_yayinEvi);
            db.SaveChanges();
            return RedirectToAction("Yayinevi");
        }

        




    
        public ActionResult Duyuru()
        {
            return View(db.duyuru.ToList());
        }
        public ActionResult DelDuyuru(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_duyuru tbl_duyuru = db.duyuru.Find(id);
            if (tbl_duyuru == null)
            {
                return HttpNotFound();
            }
            return View(tbl_duyuru);
        }
        [HttpPost, ActionName("DelDuyuru")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed5(int id)
        {
            tbl_duyuru tbl_duyuru = db.duyuru.Find(id);
            db.duyuru.Remove(tbl_duyuru);
            db.SaveChanges();
            return RedirectToAction("Duyuru");
        }










        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}