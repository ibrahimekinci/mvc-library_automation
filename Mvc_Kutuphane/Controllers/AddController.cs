using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Kutuphane.Models;
using Mvc_Kutuphane.DAL;
using System.Net;
using System.Data.Entity;
using System.IO;

namespace Mvc_Kutuphane.Controllers.Admin.add
{
    public class addController : Controller
    {
        db_Context db = new db_Context();
        public ActionResult Index()
        {
            return RedirectToAction("Kitap");
        }

        public ActionResult Admin()
        {
            List<tbl_kullanici> basici = db.kullanici.ToList();
            ViewBag.Basar = basici;
            ViewBag.rolID = new SelectList(db.rol, "ID", "ad");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Admin([Bind(Include = "ID,kadi,resimUrl,tckn,sifre,ad,soyad,cinsiyet,dogumTarihi,cepTelefonu,evTelefonu,eposta,rolID,kayitTarihi,durum")] tbl_kullanici tbl_kullanici)
        {
            if (ModelState.IsValid)
            {
                db.kullanici.Add(tbl_kullanici);
                db.SaveChanges();
                return RedirectToAction("Admin");
            }

            ViewBag.rolID = new SelectList(db.rol, "ID", "ad", tbl_kullanici.rolID);
            return View(tbl_kullanici);
        }


        public ActionResult EdKisiler(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_kullanici tbl_kullanici = db.kullanici.Find(id);
            if (tbl_kullanici == null)
            {
                return HttpNotFound();
            }
            ViewBag.rolID = new SelectList(db.rol, "ID", "ad", tbl_kullanici.rolID);
            return View(tbl_kullanici);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EdKisiler([Bind(Include = "ID,kadi,resimUrl,tckn,sifre,ad,soyad,cinsiyet,dogumTarihi,cepTelefonu,evTelefonu,eposta,rolID,kayitTarihi,durum")] tbl_kullanici tbl_kullanici)
        {
            if (ModelState.IsValid)
            {

                db.Entry(tbl_kullanici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Admin");
            }
            ViewBag.rolID = new SelectList(db.rol, "ID", "ad", tbl_kullanici.rolID);
            return View(tbl_kullanici);
        }


























        public ActionResult Kitap()
        {
            List<tbl_kitap> basici = db.kitap.ToList();
            ViewBag.Basar = basici;
            ViewBag.kitapTurID = new SelectList(db.kitapTur, "ID", "ad");
            ViewBag.yayinEviID = new SelectList(db.yayinEvi, "ID", "ad");
            ViewBag.yazarID = new SelectList(db.yazar, "ID", "ad");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Kitap([Bind(Include = "ID,ad,detay,resimUrl,iadeTarihi,kayitTarihi,ekleyenID,guncellemeTarihi,guncelleyenID,durum,kitapTurID,yazarID,yayinEviID")] tbl_kitap tbl_kitap)
        {
            if (ModelState.IsValid)
            {
                try
                {



                    ViewBag.kitapTurID = new SelectList(db.kitapTur, "ID", "ad", tbl_kitap.kitapTurID);
                    ViewBag.yayinEviID = new SelectList(db.yayinEvi, "ID", "ad", tbl_kitap.yayinEviID);
                    ViewBag.yazarID = new SelectList(db.yazar, "ID", "ad", tbl_kitap.yazarID);
                    var varMi = db.kitap.Where(x => x.ad == tbl_kitap.ad).FirstOrDefault();
                    if (varMi == null)
                    {
                        int id = int.Parse(Session["user"].ToString());
                        var kullanici = db.kullanici.Find(id);
                        tbl_kitap.kayitTarihi = DateTime.Now;
                        tbl_kitap.guncelleyenID = kullanici.ID;

                        tbl_kitap.iadeTarihi = DateTime.Now;
                        tbl_kitap.resimUrl = "http://haber.islamalemiburada.com/wp-content/uploads/2014/10/R%C3%BCyada-Kitap-G%C3%B6rmek.jpg";
                        tbl_kitap.guncellemeTarihi = DateTime.Now;
                        tbl_kitap.ekleyenID = kullanici.ID;
                        tbl_kitap.durum = true;
                        db.kitap.Add(tbl_kitap);
                        db.SaveChanges();
                        return Content("Kitap Ekleme İşlemi Gerçekleştirildi....");
                    }
                    else
                    {
                        return Content("Eklemek İstediğiniz Kitap Zaten Mevcut");
                    }




                }
                catch (Exception)
                {
                    ModelState.AddModelError("Kitap", "Bir Sorun İle Karşılaşıldı Tekrar Deneyiniz");
                    return View();
                }
            }
            return View();
        }

        public ActionResult Rol()
        {
            List<tbl_rol> basici = db.rol.ToList();
            ViewBag.Basar = basici;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rol(tbl_rol k)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var varMi = db.rol.Where(x => x.ad == k.ad).FirstOrDefault();
                    if (varMi == null)
                    {
                        int id = int.Parse(Session["user"].ToString());
                        var kullanici = db.kullanici.Find(id);
                        k.ekleyenID = kullanici.ID;
                        k.guncelleyenID = kullanici.ID;
                        k.kayitTarihi = DateTime.Now;
                        k.guncellemeTarihi = DateTime.Now;
                        k.durum = true;
                        db.rol.Add(k);
                        db.SaveChanges();
                    }
                    else
                    {
                        return Content("Eklemek İstediğiniz Rol Zaten Mevcut");
                    }

                }
                catch (Exception)
                {
                    ModelState.AddModelError("Rol", "Bir Sorun İle Karşılaşıldı Tekrar Deneyiniz");
                    return View();
                }
            }
            List<tbl_rol> basici = db.rol.ToList();
            ViewBag.Basar = basici;
            return View();
        }





        public ActionResult Yazar()
        {
            List<tbl_yazar> basici = db.yazar.ToList();
            ViewBag.Basar = basici;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Yazar(tbl_yazar k)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var varMi = db.yazar.Where(x => x.ad == k.ad).FirstOrDefault();
                    if (varMi == null)
                    {
                        int id = int.Parse(Session["user"].ToString());
                        var kullanici = db.kullanici.Find(id);
                        k.ekleyenID = kullanici.ID;
                        k.guncelleyenID = kullanici.ID;
                        k.kayitTarihi = DateTime.Now;
                        k.guncellemeTarihi = DateTime.Now;
                        k.durum = true;
                        db.yazar.Add(k);
                        db.SaveChanges();
                        return Content("Yazar Ekleme İşleminiz Gerçekleşti....");
                    }
                    else
                    {
                        return Content("Eklemek İstediğiniz Yazar Zaten Mevcut");
                    }

                }
                catch (Exception)
                {
                    ModelState.AddModelError("Yazar", "Bir Sorun İle Karşılaşıldı Tekrar Deneyiniz");
                    return View();
                }
            }
            return View();
        }







        public ActionResult KitapTur()
        {
            List<tbl_kitapTur> basici = db.kitapTur.ToList();
            ViewBag.Basar = basici;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KitapTur(tbl_kitapTur k)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var varMi = db.kitapTur.Where(x => x.ad == k.ad).FirstOrDefault();
                    if (varMi == null)
                    {

                        int id = int.Parse(Session["user"].ToString());
                        var kullanici = db.kullanici.Find(id);
                        k.ustID = kullanici.ID;
                        k.iconHtml = "https://cdn2.iconfinder.com/data/icons/windows-8-metro-style/128/book.png";
                        k.ekleyenID = kullanici.ID;
                        k.guncelleyenID = kullanici.ID;
                        k.kayitTarihi = DateTime.Now;
                        k.resimUrl = "https://cdn2.iconfinder.com/data/icons/windows-8-metro-style/128/book.png";
                        k.guncellemeTarihi = DateTime.Now;
                        k.durum = true;
                        db.kitapTur.Add(k);
                        db.SaveChanges();
                        return Content("Kitap Türü Ekleme İşlemi Gerçekleştirildi...");
                    }
                    else
                    {
                        return Content("Eklemek İstediğini Kitap Evi Zaten Mevcut");
                    }

                }
                catch (Exception)
                {
                    ModelState.AddModelError("KitapTur", "Bir Sorun İle Karşılaşıldı Tekrar Deneyiniz");
                    return View();
                }
            }
            return View();
        }





        public ActionResult Yayinevi()
        {
            List<tbl_yayinEvi> basici = db.yayinEvi.ToList();
            ViewBag.Basar = basici;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Yayinevi(tbl_yayinEvi k)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var varMi = db.yayinEvi.Where(x => x.ad == k.ad).FirstOrDefault();
                    if (varMi == null)
                    {

                        int id = int.Parse(Session["user"].ToString());
                        var kullanici = db.kullanici.Find(id);
                        k.ekleyenID = kullanici.ID;
                        k.guncelleyenID = kullanici.ID;
                        k.kayitTarihi = DateTime.Now;
                        k.resimUrl = "http://www.domingo.com.tr/wp-content/uploads/2015/07/1000Nokta_Kapak_On-731x1024.jpg";
                        k.guncellemeTarihi = DateTime.Now;
                        k.durum = true;
                        db.yayinEvi.Add(k);
                        db.SaveChanges();
                        return Content("Yayın Evi Ekleme İşlemi Gerçekleştirildi...");
                    }
                    else
                    {
                        return Content("Eklemek İstediğini Yayın Evi Zaten Mevcut");
                    }

                }
                catch (Exception)
                {
                    ModelState.AddModelError("Yayinevi", "Bir Sorun İle Karşılaşıldı Tekrar Deneyiniz");
                    return View();
                }
            }
            return View();

        }


        public ActionResult Duyuru()
        {
            List<tbl_duyuru> basici = db.duyuru.ToList();
            ViewBag.Basar = basici;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duyuru(tbl_duyuru k)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var varMi = db.duyuru.Where(x => x.ad == k.ad).FirstOrDefault();
                    if (varMi == null)
                    {

                        int id = int.Parse(Session["user"].ToString());
                        var kullanici = db.kullanici.Find(id);
                        k.bitisTarihi = DateTime.Now;
                        k.ekleyenID = kullanici.ID;
                        k.guncelleyenID = kullanici.ID;
                        k.kayitTarihi = DateTime.Now;
                        k.resimUrl = "http://sks.fsm.edu.tr/resimler/upload/duyuru22015-03-13-04-17-04am.jpg";
                        k.guncellemeTarihi = DateTime.Now;
                        k.durum = true;
                        db.duyuru.Add(k);
                        db.SaveChanges();
                        return Content("Eklemek İstediğiniz Duyuru Başarı İle Eklendi .... ");
                    }
                    else
                    {
                        return Content("Eklemek İstediğini Duyuru Zaten Mevcut");
                    }

                }
                catch (Exception)
                {
                    ModelState.AddModelError("Duyuru", "Bir Sorun İle Karşılaşıldı Tekrar Deneyiniz");
                    return View();
                }
            }
            return View();


        }
    }
}