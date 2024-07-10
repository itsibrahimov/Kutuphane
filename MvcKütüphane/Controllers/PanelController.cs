using MvcKütüphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcKütüphane.Controllers
{
    public class PanelController : Controller
    {
        // GET: Panel
        DBKÜTÜPHANEEntities db = new DBKÜTÜPHANEEntities();
        [HttpGet]
        public ActionResult Index(TBLÜYELER t)
        {
            var uyemail = (string)Session["Mail"];
           // var degerler = db.TBLÜYELER.FirstOrDefault(z =>z.MAIL == uyemail);
           var degerler = db.TBLDUYURULAR.ToList();
            var d1 = db.TBLÜYELER.Where(x=>x.MAIL == uyemail).Select(y=>y.AD).FirstOrDefault();
            ViewBag.d1 = d1;

            var d2 = db.TBLÜYELER.Where(x => x.MAIL == uyemail).Select(y => y.SOYAD).FirstOrDefault();
            ViewBag.d2 = d2;

            var d3 = db.TBLÜYELER.Where(x => x.MAIL == uyemail).Select(y => y.FOTOGRAF).FirstOrDefault();
            ViewBag.d3 = d3;

            var d4 = db.TBLÜYELER.Where(x => x.MAIL == uyemail).Select(y => y.KULLANICIADI).FirstOrDefault();
            ViewBag.d4 = d4;

            var d5 = db.TBLÜYELER.Where(x => x.MAIL == uyemail).Select(y => y.OKUL).FirstOrDefault();
            ViewBag.d5 = d5;

            var d6 = db.TBLÜYELER.Where(x => x.MAIL == uyemail).Select(y => y.TELEFON).FirstOrDefault();
            ViewBag.d6 = d6;

            var d7 = db.TBLÜYELER.Where(x => x.MAIL == uyemail).Select(y => y.MAIL).FirstOrDefault();
            ViewBag.d7 = d7;

            ViewBag.d1 = d1;
            ViewBag.d2 = d2;
            ViewBag.d3 = d3;
            ViewBag.d4 = d4;
            ViewBag.d5 = d5;
            ViewBag.d6 = d6;
            ViewBag.d7 = d7;
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(TBLÜYELER p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.TBLÜYELER.FirstOrDefault(x =>x.MAIL == kullanici);
            uye.SIFRE = p.SIFRE;
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.FOTOGRAF = p.FOTOGRAF;
            uye.OKUL = p.OKUL;
            uye.KULLANICIADI = p.KULLANICIADI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Kitaplarim()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TBLÜYELER.Where(x => x.MAIL == kullanici.ToString()).Select(z =>z.ID).FirstOrDefault();
            var degerler = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            return View(degerler);
        }
        public ActionResult Duyurular()
        {
            var duyurulistesi = db.TBLDUYURULAR.ToList();
            return View(duyurulistesi);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }

        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        public PartialViewResult Partial2()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TBLÜYELER.Where(x=>x.MAIL == kullanici).Select(z =>z.ID).FirstOrDefault();
            var uyegetir = db.TBLÜYELER.Find(id);
            return PartialView("Partial2", uyegetir);
        }
    }
}