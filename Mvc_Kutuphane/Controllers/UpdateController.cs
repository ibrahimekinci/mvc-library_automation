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
    public class UpdateController : Controller
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


        public ActionResult EdRol(int? id)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EdRol([Bind(Include = "ID,ad,resimUrl,kayitTarihi,guncellemeTarihi,durum,ekleyenID,guncelleyenID")] tbl_rol tbl_rol)
        {
            if (ModelState.IsValid)
            {
                int id = int.Parse(Session["user"].ToString());
                var kullanici = db.kullanici.Find(id);
                tbl_rol.guncelleyenID = kullanici.ID;
                tbl_rol.guncellemeTarihi = DateTime.Now;
                tbl_rol.durum = true;
                db.Entry(tbl_rol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Rol");
            }
            return View(tbl_rol);
        }








        public ActionResult Kitap()
        {
            var kitap = db.kitap.Include(t => t.kitapTur).Include(t => t.yayinEvi).Include(t => t.yazar);
            return View(kitap.ToList());
        }

        public ActionResult EDKitap(int? id)
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
            ViewBag.kitapTurID = new SelectList(db.kitapTur, "ID", "ad", tbl_kitap.kitapTurID);
            ViewBag.yayinEviID = new SelectList(db.yayinEvi, "ID", "ad", tbl_kitap.yayinEviID);
            ViewBag.yazarID = new SelectList(db.yazar, "ID", "ad", tbl_kitap.yazarID);
            return View(tbl_kitap);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EDKitap([Bind(Include = "ID,ad,detay,resimUrl,iadeTarihi,kayitTarihi,ekleyenID,guncellemeTarihi,guncelleyenID,durum,kitapTurID,yazarID,yayinEviID")] tbl_kitap tbl_kitap)
        {
            if (ModelState.IsValid)
            {
                int id = int.Parse(Session["user"].ToString());
                var kullanici = db.kullanici.Find(id);
                tbl_kitap.guncelleyenID = kullanici.ID;
                tbl_kitap.guncellemeTarihi = DateTime.Now;
                tbl_kitap.durum = true;
                db.Entry(tbl_kitap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Kitap");
            }
            ViewBag.kitapTurID = new SelectList(db.kitapTur, "ID", "ad", tbl_kitap.kitapTurID);
            ViewBag.yayinEviID = new SelectList(db.yayinEvi, "ID", "ad", tbl_kitap.yayinEviID);
            ViewBag.yazarID = new SelectList(db.yazar, "ID", "ad", tbl_kitap.yazarID);
            return View(tbl_kitap);
        }















        public ActionResult Yazar()
        {
            return View(db.yazar.ToList());
        }
        public ActionResult EDYazar(int? id)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EDYazar([Bind(Include = "ID,ad,soyad,dogumTarihi,kayitTarihi,guncellemeTarihi,durum,ekleyenID,guncelleyenID")] tbl_yazar tbl_yazar)
        {
            if (ModelState.IsValid)
            {

                int id = int.Parse(Session["user"].ToString());
                var kullanici = db.kullanici.Find(id);
                tbl_yazar.guncelleyenID = kullanici.ID;
                tbl_yazar.guncellemeTarihi = DateTime.Now;
                tbl_yazar.durum = true;
                db.Entry(tbl_yazar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Yazar");
            }
            return View(tbl_yazar);
        }






        public ActionResult KitapTur()
        {
            return View(db.kitapTur.ToList());
        }
        public ActionResult EDKitapTur(int? id)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EDKitapTur([Bind(Include = "ID,ad,ustID,iconHtml,resimUrl,kayitTarihi,ekleyenID,guncellemeTarihi,guncelleyenID,durum")] tbl_kitapTur tbl_kitapTur)
        {
            if (ModelState.IsValid)
            {

                int id = int.Parse(Session["user"].ToString());
                var kullanici = db.kullanici.Find(id);
                tbl_kitapTur.guncelleyenID = kullanici.ID;
                tbl_kitapTur.guncellemeTarihi = DateTime.Now;
                tbl_kitapTur.durum = true;

                db.Entry(tbl_kitapTur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("KitapTur");
            }
            return View(tbl_kitapTur);
        }





        public ActionResult Yayinevi()
        {
            return View(db.yayinEvi.ToList());
        }

        public ActionResult EDYayinevi(int? id)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EDYayinevi([Bind(Include = "ID,ad,aciklama,detay,resimUrl,kayitTarihi,durum,ekleyenID,guncellemeTarihi,guncelleyenID")] tbl_yayinEvi tbl_yayinEvi)
        {
            if (ModelState.IsValid)
            {


                int id = int.Parse(Session["user"].ToString());
                var kullanici = db.kullanici.Find(id);
                tbl_yayinEvi.guncelleyenID = kullanici.ID;

                tbl_yayinEvi.durum = true;


                tbl_yayinEvi.guncellemeTarihi = DateTime.Now;

                db.Entry(tbl_yayinEvi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Yayinevi");
            }
            return View(tbl_yayinEvi);
        }

        public ActionResult Duyuru()
        {
            return View(db.duyuru.ToList());
        }

        public ActionResult EdDuyuru(int? id)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EdDuyuru([Bind(Include = "ID,ad,aciklama,detay,resimUrl,kayitTarihi,bitisTarihi,guncellemeTarihi,durum,ekleyenID,guncelleyenID")] tbl_duyuru tbl_duyuru)
        {
            if (ModelState.IsValid)
            {
                int id = int.Parse(Session["user"].ToString());
                var kullanici = db.kullanici.Find(id);
                tbl_duyuru.guncelleyenID = kullanici.ID;
                tbl_duyuru.guncellemeTarihi = DateTime.Now;
                tbl_duyuru.durum = true;
                db.Entry(tbl_duyuru).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Duyuru");
            }
            return View(tbl_duyuru);
        }
    }
}