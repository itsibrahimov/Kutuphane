using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKütüphane.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcKütüphane.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        DBKÜTÜPHANEEntities db = new DBKÜTÜPHANEEntities();
        public ActionResult Index(int sayfa =1)
        {
            //var degerler = db.TBLÜYELER.ToList();
            var degerler = db.TBLÜYELER.ToList().ToPagedList(sayfa, 3);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeEkle(TBLÜYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.TBLÜYELER.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult UyeSil(int id)
        {
            var uye = db.TBLÜYELER.Find(id);
            db.TBLÜYELER.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int id)
        {
            var uye = db.TBLÜYELER.Find(id);
            return View("UyeGetir", uye);
        }
        public ActionResult UyeGuncelle(TBLÜYELER p)
        {
            var prs = db.TBLÜYELER.Find(p.ID);
            prs.AD = p.AD;
            prs.SOYAD = p.SOYAD;
            prs.SOYAD = p.MAIL;
            prs.KULLANICIADI = p.KULLANICIADI;
            prs.SIFRE = p.SIFRE;
            prs.OKUL = p.OKUL;
            prs.TELEFON = p.TELEFON;
            prs.FOTOGRAF = p.FOTOGRAF;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeKitapGecmis (int id)
        {
            var ktpgecmis = db.TBLHAREKET.Where(x=>x.UYE==id).ToList();
            var uyektp = db.TBLÜYELER.Where(y=>y.ID==id).Select(z=>z.AD +" "+z.SOYAD).FirstOrDefault();
            ViewBag.u1 = uyektp;
            return View(ktpgecmis);
        }
    }
}