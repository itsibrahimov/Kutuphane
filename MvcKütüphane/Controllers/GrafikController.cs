using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKütüphane.Models;

namespace MvcKütüphane.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeKitapResult()
        {
            return Json(liste());
        }
        public List<Class1> liste()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                yayinevi = "Güneş",
                sayı = 7
            });
            cs.Add(new Class1()
            {
                yayinevi = "Mars",
                sayı = 4
            });
            cs.Add(new Class1()
            {
                yayinevi = "Jupiter",
                sayı = 6
            });
            return cs;
        }
    }
}