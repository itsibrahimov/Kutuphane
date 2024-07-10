using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKütüphane.Models.Entity;

namespace MvcKütüphane.Controllers
{
    public class IstatistikController : Controller
    {
        DBKÜTÜPHANEEntities db = new DBKÜTÜPHANEEntities();
        // GET: Istatistik
        public ActionResult Index()
        {
            var deger1 = db.TBLÜYELER.Count();
            var deger2 = db.TBLKİTAP.Count();
            var deger3 = db.TBLKİTAP.Where(x=>x.DURUM == false).Count();
            var deger4 = db.TBLCEZALAR.Sum(x => x.PARA);
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            return View();
        }
        public ActionResult Hava()
        {
            return View();
        }
        public ActionResult HavaKart()
        {
            return View();
        }
        public ActionResult Galeri() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResimYukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu);
            }
            return RedirectToAction ("Galeri");
        }
        public ActionResult LinqKart()
        {
            var deger1 = db.TBLKİTAP.Count();
            var deger2 = db.TBLÜYELER.Count();
            var deger3 = db.TBLCEZALAR.Sum(x=>x.PARA);
            var deger4 = db.TBLKİTAP.Where(x =>x.DURUM ==false).Count();
            var deger5 = db.TBLKATEGORİ.Count();
            var deger6 = db.TBLILETISIM.Count();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            ViewBag.dgr5 = deger5;
            ViewBag.dgr6 = deger6;
            return View();
        }
    }
}