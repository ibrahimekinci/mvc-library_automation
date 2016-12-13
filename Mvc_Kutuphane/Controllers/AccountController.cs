using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Kutuphane.Models;
using Mvc_Kutuphane.DAL;
using System.IO;

namespace Mvc_Kutuphane.Controllers
{
    public class AccountController : Controller
    {
        db_Context db = new db_Context();

        public ActionResult Index()
        {
            return RedirectToAction("Profil");
        }

        public ActionResult Profil()
        {
            try
            {
                if (Session["user"] == null)
                    return RedirectToAction("login", "Account");

                int id = int.Parse(Session["user"].ToString());
                var kullanici = db.kullanici.Find(id);

                return View(kullanici);
            }
            catch (Exception)
            {
                return RedirectToAction("mesaj", "Home", new { mesaj = "Account sayfasında hatalar oluştu", link = "/Account" });
            }
        }
        [HttpPost]
        public ActionResult Profil(tbl_kullanici mdl)
        {
            if (Session["user"] == null)
                return RedirectToAction("login", "Account");

            mdl.rolID = 3;
            mdl.kayitTarihi = DateTime.Now;
            mdl.durum = true;


            int id = int.Parse(Session["user"].ToString());
            var kullanici = db.kullanici.Find(id);

            if (ModelState.IsValid)
            {
                try
                {
                    mdl.sifre += "^#$½123456789";
                    mdl.sifre = sifreIslemleri.convertMd5(mdl.sifre);
                    string hata = "";
                    bool sonuc = true;
                    if (mdl.sifre != kullanici.sifre)
                    {
                        sonuc = false;
                        hata = " Şifrenizi hatalı girdiniz";
                    }

                    if (sonuc == true && kullanici.kadi != mdl.kadi && db.kullanici.Where(x => x.kadi == mdl.kadi).Count() > 0)
                    {
                        sonuc = false;
                        hata = " Kullanıcı adı zaten başka bir hesap tarafında kullanılmakta";
                    }

                    if (sonuc == true && kullanici.eposta != mdl.eposta && db.kullanici.Where(x => x.eposta == mdl.eposta).Count() > 0)
                    {
                        sonuc = false;
                        hata = " Eposta zaten başka bir hesap tarafında kullanılmakta";
                    }

                    if (sonuc)
                    {
                        kullanici.ad = mdl.ad;
                        kullanici.soyad = mdl.soyad;
                        kullanici.eposta = mdl.eposta;
                        kullanici.kadi = mdl.kadi;
                        kullanici.tckn = mdl.tckn;
                        kullanici.cepTelefonu = mdl.cepTelefonu;
                        kullanici.evTelefonu = mdl.evTelefonu;

                        kullanici.cinsiyet = mdl.cinsiyet;
                        kullanici.dogumTarihi = mdl.dogumTarihi;
                        db.SaveChanges();
                        ViewBag.Mesaj = "Başarıyla güncellendi.";
                    }
                    if (!sonuc)
                    {
                        ModelState.AddModelError("Profil", hata);
                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("mesaj", "Home", new { mesaj = "Üyelik sayfasında hatalar oluştu", link = "/Account/signup" });
                }
            }
            return View(kullanici);
        }

        public ActionResult sifreyiDegistir()
        {
            try
            {
                if (Session["user"] == null)
                    return RedirectToAction("login", "Account");
            }
            catch (Exception)
            {
                return RedirectToAction("mesaj", "Home", new { mesaj = "Şifre değiştirme sayfasında hatalar oluştu", link = "/Account/sifreyiDegistir" });
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult sifreyiDegistir(sifreDegistir sd)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Session["user"] == null)
                        return RedirectToAction("login", "Account");

                    int id = int.Parse(Session["user"].ToString());
                    var kullanici = db.kullanici.Find(id);
                    sd.sifre += "^#$½123456789";
                    sd.sifre = sifreIslemleri.convertMd5(sd.sifre);
                    if (sd.sifre == kullanici.sifre)
                    {
                        sd.yeniSifre += "^#$½123456789";
                        sd.yeniSifre = sifreIslemleri.convertMd5(sd.yeniSifre);
                        kullanici.sifre = sd.yeniSifre;
                        db.SaveChanges();
                        ViewBag.Mesaj = "Başarıyla güncellendi.";
                    }
                    else
                    {
                        ModelState.AddModelError("SifreDegistir", "Şu an kullanımda olan şifrenizi eksik girdiniz yada hatalı girdiniz.");
                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("mesaj", "Home", new { mesaj = "Üyelik sayfasında hatalar oluştu", link = "/Account/signup" });
                }
            }

            return View();
        }

        public ActionResult FotografYukle()
        {
            try
            {
                if (Session["user"] == null)
                    return RedirectToAction("login", "Account");
                int id = int.Parse(Session["user"].ToString());
                var kullanici = db.kullanici.Find(id);
                if (kullanici != null)
                {
                    ViewBag.resimUrl = kullanici.resimUrl;
                }
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("mesaj", "Home", new { mesaj = "Fotoğraf yükleme sayfasında hatalar oluştu", link = "/Account/FotografYukle" });
            }

        }
        [HttpPost]
        public ActionResult FotografYukle(HttpPostedFileBase FileResim)
        {
            try
            {
                if (Session["user"] == null)
                    return RedirectToAction("login", "Account");

                int id = int.Parse(Session["user"].ToString());
                var kullanici = db.kullanici.Find(id);
                if (kullanici != null)
                {
                    //if (Request.Files.Count > 0)
                    //{
                    //    var file = Request.Files[0];

                    //    if (file != null && file.ContentLength > 0)
                    //    {
                    //        var fileName = Path.GetFileName(file.FileName);
                    //        var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    //        file.SaveAs(path);
                    //    }
                    //}

                    if (FileResim != null && FileResim.ContentLength > 0)
                    {
                        string[] uzantilar = { ".JPG", ".JPEG", ".PNG", ".BMP", ".GIF" };
                        string uzanti = "";
                        bool sonuc = false;
                        for (int i = 0; i < uzantilar.Count(); i++)
                        {
                            if (FileResim.FileName.ToString().ToUpper().EndsWith(uzantilar[i]))
                            {
                                sonuc = true;
                                uzanti = uzantilar[i];
                            }
                        }
                        if (sonuc)
                        {
                            kullanici.resimUrl = "/assets/img/Profil/" + id.ToString() + uzanti;
                            var path = Path.Combine(Server.MapPath("~/assets/img/Profil/"), id.ToString() + uzanti);
                            FileResim.SaveAs(path);
                            db.SaveChanges();
                            ViewBag.resimUrl = kullanici.resimUrl;
                            ViewBag.Mesaj = "Başarıyla güncellendi.";
                        }
                        else
                        {
                            ModelState.AddModelError("", "Lütfen sadece  resim formatında bir dosya seçiniz");
                        }


                    }
                    else
                    {
                        ModelState.AddModelError("", "Lütfen bir resim seçiniz");
                    }
                }
            }
            catch (Exception)
            {
                return RedirectToAction("mesaj", "Home", new { mesaj = "Üyelik sayfasında hatalar oluştu", link = "/Account/signup" });
            }

            return View();
        }
        public ActionResult Bildirimler()
        {
            try
            {
                if (Session["user"] == null)
                    return RedirectToAction("login", "Account");
            }
            catch (Exception)
            {
                return RedirectToAction("hata", "Home");
            }

            return View();
        }

        public ActionResult KitapSepet()
        {
            try
            {
                if (Session["user"] == null)
                    return RedirectToAction("login", "Account");
            }
            catch (Exception)
            {
                return RedirectToAction("hata", "Home");
            }

            return View();
        }


        public ActionResult KitapGecmis()
        {
            try
            {
                if (Session["user"] == null)
                    return RedirectToAction("login", "Account");
            }
            catch (Exception)
            {
                return RedirectToAction("hata", "Home");
            }

            return View();
        }

        public ActionResult HesapSil()
        {
            try
            {
                if (Session["user"] == null)
                    return RedirectToAction("login", "Account");
            }
            catch (Exception)
            {
                return RedirectToAction("hata", "Home");
            }

            return View();
        }


        public ActionResult login(string mesaj)
        {

            ViewBag.Mesaj = mesaj;
            try
            {
                if (Session["user"] != null)
                    return RedirectToAction("index", "Account");
            }
            catch (Exception)
            {
                return RedirectToAction("hata", "Home");
            }

            return View();
        }
        [HttpPost]
        public ActionResult login(login l)
        {

            try
            {
                if (Session["user"] != null)
                    return RedirectToAction("index", "Account");
                //çerez oluşturduk

                Response.Cookies["user"].Expires = DateTime.Now.AddDays(1);
                l.sifre += "^#$½123456789";
                l.sifre = sifreIslemleri.convertMd5(l.sifre);
            
                var kullanici = db.kullanici.Where(x => (x.kadi.ToLower() == l.kadi.ToLower() && x.sifre == l.sifre) || (x.eposta == l.kadi && x.sifre == l.sifre)).FirstOrDefault();
                if (kullanici != null)
                {

                    Session["user"] = kullanici.ID;
                    string yetki = "";
                    string yetkiGecici = "";
                    foreach (var item in kullanici.rol.rolYetki)
                    {
                        string ad = item.rolYetkiListe.ad;
                        if (ad != "admin" || ad != "rol")
                        {
                            yetkiGecici += genel.ToTitleCase(ad);
                            if (item.add)
                                yetkiGecici += ",add";
                            if (ad != "admin")
                            {
                                if (item.delete)
                                    yetkiGecici += ",delete";
                                if (item.update)
                                    yetkiGecici += ",update";
                            }
                          
                            yetki = yetkiGecici;
                            yetkiGecici += ";";
                        }
                    }
                    Session["yetki"] = yetki;
                    return RedirectToAction("Profil", "Account");
                }
                else
                {
                    ModelState.AddModelError("_login", "Hatalı giriş yaptınız.Lütfen tekrar deneyiniz.");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("hata", "Home");
            }
            return View();
        }
        public ActionResult signup()
        {
            try
            {
                if (Session["user"] != null)
                    return RedirectToAction("Index", "Account");
            }
            catch (Exception)
            {
                return RedirectToAction("hata", "Home");
            }

            return View();
        }

        public ActionResult signout()
        {
            Session["user"] = null;
            Session["yetki"] = null;

            return RedirectToAction("Index", "Home");
        }

        [ChildActionOnly]
        public ActionResult _banner()
        {
            try
            {
                int id = Convert.ToInt32(Session["user"]);
                var kullanici = db.kullanici.Find(id);
                ViewBag.resimUrl = kullanici.resimUrl;
                ViewBag.rol = kullanici.rol.ad;
                ViewBag.ad = kullanici.ad;
            }
            catch (Exception)
            {
                Response.Redirect("/Home/hata");
            }
            return View();
        }
        [ChildActionOnly]
        public ActionResult _register()
        {

            return View();
        }
        [HttpPost]
        [ChildActionOnly]
        public ActionResult _register(tbl_kullanici k)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var varMi = db.kullanici.Where(x => x.kadi == k.kadi || x.eposta == k.eposta).FirstOrDefault();
                    if (varMi == null)
                    {
                        k.sifre += "^#$½123456789";
                        k.sifre = sifreIslemleri.convertMd5(k.sifre);
                        k.rolID = 3;
                        k.kayitTarihi = DateTime.Now;
                        k.resimUrl = "/assets/img/Profil/profilDefault.jpg";
                        k.durum = true;
                        db.kullanici.Add(k);
                        db.SaveChanges();
                        Response.Redirect(Url.Action("login", "Account", new { mesaj = "Üyeliğiniz gerçekleşti.Şimdi Giriş Yapabilirsiniz." }));
                    }
                    else
                    {
                        ModelState.AddModelError("_register", "Kullanıcı adı veya Eposta daha önce kullanılmış..");
                    }

                }
                catch (Exception)
                {
                    return RedirectToAction("hata", "Home");
                }
            }
            return View();
        }

        public ActionResult forgot_password()
        {
            try
            {
                if (Session["user"] != null)
                    Response.Redirect("~/Account/index");
            }
            catch (Exception)
            {
                return RedirectToAction("hata", "Home");
            }

            return PartialView();
        }
    }
}