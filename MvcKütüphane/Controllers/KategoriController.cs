using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKütüphane.Models.Entity;

namespace MvcKütüphane.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DBKÜTÜPHANEEntities db = new DBKÜTÜPHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORİ.Where(x =>x.DURUM == true).ToList();
            return View(degerler);
        }
        [HttpPost]
        public ActionResult KategoriEkle(TBLKATEGORİ p)
        {
            db.TBLKATEGORİ.Add(p);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TBLKATEGORİ.Find(id);
            //db.TBLKATEGORİ.Remove(kategori);
            kategori.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TBLKATEGORİ.Find(id);
            return View("KategoriGetir", ktg);
        }
        public ActionResult KategoriGuncelle(TBLKATEGORİ p)
        {
            var ktg = db.TBLKATEGORİ.Find(p.ID);
            ktg.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}