using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKütüphane.Models.Entity;

namespace MvcKütüphane.Controllers
{
    public class MesajController : Controller
    {
        // GET: Mesaj
        DBKÜTÜPHANEEntities db = new DBKÜTÜPHANEEntities();
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesaj = db.TBLMESAJ.Where(x => x.ALICI == uyemail.ToString()).ToList();
            return View(mesaj);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(TBLMESAJ t)
        {
            var uyemail = (string)Session["Mail"].ToString();
            t.GONDEREN = uyemail.ToString();
            t.TARIH =DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLMESAJ.Add(t);
            db.SaveChanges();
            return RedirectToAction("GidenMesaj", "Mesaj");
        }
        public ActionResult GidenMesaj()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesaj = db.TBLMESAJ.Where(x => x.GONDEREN == uyemail.ToString()).ToList();
            return View(mesaj);
        }
        public PartialViewResult Partial1()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var gelensayisi = db.TBLMESAJ.Where(x=>x.ALICI == uyemail).Count();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = db.TBLMESAJ.Where(x => x.GONDEREN == uyemail).Count();
            ViewBag.d2 = gidensayisi;

            return PartialView();
        }
    }
}