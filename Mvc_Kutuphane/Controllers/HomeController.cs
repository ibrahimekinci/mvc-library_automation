using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Mvc_Kutuphane.Models;
using Mvc_Kutuphane.DAL;
using System.Data.Entity;
using System.Web.UI.WebControls;

namespace Mvc_Kutuphane.Controllers
{
    public class HomeController : Controller
    {
        db_Context db = new db_Context();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult kitap(string kitapAdi, string yazarAdi, string turAdi, string yayineviAdi)
        {

            List<tbl_kitap> m = new List<tbl_kitap>();
            try
            {
                if (Session["aramaGecici"] != null)
                {
                    //Anasayfada yapılan aramaları tutaacak
                    string[] indexArama = Session["aramaGecici"].ToString().Split(':');
                    switch (indexArama[0])
                    {
                        case "kitapAdi":
                            kitapAdi = indexArama[1];
                            break;
                        case "yazar":
                            yazarAdi = indexArama[1];
                            break;
                        case "tur":
                            turAdi = indexArama[1];
                            break;
                        case "kitapevi":
                            yayineviAdi = indexArama[1];
                            break;
                    }
                    Session["aramaGecici"] = null;
                }
                bool sonuc = false;
                bool dbBaglandimi = false;
                if (!string.IsNullOrEmpty(kitapAdi))
                {
                    if (dbBaglandimi)
                    {
                        m = m.Where(x => (x.ad).Contains(kitapAdi)).ToList();
                        dbBaglandimi = true;
                    }
                    else
                        m = db.kitap.Where(x => (x.ad).Contains(kitapAdi)).ToList();
                    sonuc = true;
                }
                if (!string.IsNullOrEmpty(yazarAdi))
                {
                    if (dbBaglandimi)
                    {
                        m = m.Where(x => (x.yazar.ad + " " + x.yazar.soyad).Contains(yazarAdi)).ToList();
                        dbBaglandimi = true;
                    }
                    else
                        m = db.kitap.Where(x => (x.yazar.ad + " " + x.yazar.soyad).Contains(yazarAdi)).ToList();
                    sonuc = true;
                }
                if (!string.IsNullOrEmpty(turAdi))
                {
                    if (dbBaglandimi)
                    {
                        m = m.Where(x => (x.kitapTur.ad).Contains(turAdi)).ToList();
                        dbBaglandimi = true;
                    }
                    else
                        m = db.kitap.Where(x => (x.kitapTur.ad).Contains(turAdi)).ToList();
                    sonuc = true;
                }
                if (!string.IsNullOrEmpty(yayineviAdi))
                {
                    if (dbBaglandimi)
                    {
                        m = m.Where(x => (x.yayinEvi.ad).Contains(yayineviAdi)).ToList();
                        dbBaglandimi = true;
                    }
                    else
                        m = db.kitap.Where(x => (x.yayinEvi.ad).Contains(yayineviAdi)).ToList();
                    sonuc = true;
                }
                if (!sonuc)
                {
                    m = db.kitap.OrderByDescending(x => x.kayitTarihi).Take(100).ToList();
                }
                return View(m);
            }
            catch (Exception)
            {
                return View(m);
            }
        }
        public ActionResult kitapDetay(int? ID)
        {
            if (ID == null || ID == 0)
                return RedirectToAction("Kitap", "Home");
            try
            {
                var m = db.kitap.Find(ID);
                return View(m);
            }
            catch (Exception)
            {

                return RedirectToAction("Kitap", "Home");
            }
        }


        public ActionResult Create(int? id)
        {
            ViewBag.kitapID = new SelectList(db.kitap, "ID", "ad");
            ViewBag.kullaniciID = new SelectList(db.kullanici, "ID", "kadi");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int? id, [Bind(Include = "ID,kayitTarihi,kitapID,kullaniciID")] tbl_kitapSepet tbl_kitapSepet)
        {
            var k = db.kitapSepet.Find(id);
            if (k == null)
            {
                if (ModelState.IsValid)
                {

                    int kay = int.Parse(Session["user"].ToString());
                    var kullanici = db.kullanici.Find(kay);

                    tbl_kitapSepet.kayitTarihi = DateTime.Now;
                    tbl_kitapSepet.kullaniciID = kullanici.ID;
                    var m = db.kitap.Find(id);
                    tbl_kitapSepet.kitapID = m.ID;


                    db.kitapSepet.Add(tbl_kitapSepet);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.kitapID = new SelectList(db.kitap, "ID", "ad", tbl_kitapSepet.kitapID);
                ViewBag.kullaniciID = new SelectList(db.kullanici, "ID", "kadi", tbl_kitapSepet.kullaniciID);
                return View(tbl_kitapSepet);
            }
            else
            {

                return Content("Malesef Bu kitap Başka Kullanıcımız Tarafından Ayırtılmış:(");
            }
        }






















        public ActionResult _counter()
        {
            ViewBag.KitapSayisi = db.kitap.Count();
            return View();
        }
        public ActionResult _featured()
        {
            try
            {
                var m = db.kitap.Take(5).OrderBy(x => x.kitapHaraket.Count()).ToList();
                if (m.Count > 0)
                    return View(m);
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public ActionResult mesaj(string mesaj, string link)
        {
            ViewBag.Mesaj = mesaj;
            ViewBag.link = link;
            return View();
        }
        public ActionResult ara()
        {
            return View();
        }

        public ActionResult _kitapTur()
        {
            //Session["aramaGecici"] = "kitapTur:" + aranan;
            try
            {
                var m = db.kitapTur.OrderBy(x => x.ad).Take(8).ToList();
                if (m.Count > 0)
                    return View(m);
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public ActionResult _banner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult _banner(string aranan, string aramaKriteri)
        {
            if (!string.IsNullOrEmpty(aranan))
            {
                switch (aramaKriteri)
                {
                    default:
                        Session["aramaGecici"] = "kitapAdi:" + aranan;
                        Response.Redirect(Url.Action("kitap", "Home"));
                        break;
                    case "yazar":
                        Session["aramaGecici"] = "yazarAdi:" + aranan;
                        Response.Redirect(Url.Action("kitap", "Home"));
                        break;
                    case "tur":
                        Session["aramaGecici"] = "turAdi:" + aranan;
                        Response.Redirect(Url.Action("kitap", "Home"));
                        break;
                    case "kitapevi":
                        Session["aramaGecici"] = "kitapeviAdi:" + aranan;
                        Response.Redirect(Url.Action("kitap", "Home"));
                        break;
                }
            }
            return View();

        }
        public ActionResult _announcement()
        {
            try
            {
                var m = db.duyuru.Take(5).OrderByDescending(x => x.kayitTarihi).ToList();
                if (m.Count > 0)
                    return View(m);
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            Session["Culture"] = new CultureInfo(lang);
            return Redirect(returnUrl);
        }

        public ActionResult iletisim()
        {
            return View();
        }

        [HttpPost]
        public ActionResult iletisim(string mail, string konu, string ileti)
        {
            try
            {
                WebMail.SmtpServer = "smtp.live.com";
                WebMail.EnableSsl = true;
                WebMail.UserName = "mvckutuphanemiz@hotmail.com";
                WebMail.Password = "mvc123456";
                WebMail.SmtpPort = 587;
                WebMail.Send(
                        "mvckutuphanemiz@hotmail.com",
                        konu,
                        ileti,
                        mail
                    );

                return RedirectToAction("mesaj", "Home", new { mesaj = "iletişim Formunuz başarıyla gönderildi" });
            }
            catch (Exception ex)
            {
                ViewData.ModelState.AddModelError("_HATA", ex.Message);
            }

            return View();
        }
    }
}