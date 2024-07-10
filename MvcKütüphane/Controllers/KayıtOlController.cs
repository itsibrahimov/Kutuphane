using MvcKütüphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKütüphane.Controllers
{
    [AllowAnonymous]
    public class KayıtOlController : Controller
    {
        // GET: KayıtOl

        DBKÜTÜPHANEEntities db = new DBKÜTÜPHANEEntities();
        [HttpGet]
        public ActionResult Kayıt()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayıt(TBLÜYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayıt");
            }
            db.TBLÜYELER.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}