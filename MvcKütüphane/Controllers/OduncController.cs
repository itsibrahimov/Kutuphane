﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKütüphane.Models.Entity;

namespace MvcKütüphane.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        DBKÜTÜPHANEEntities db = new DBKÜTÜPHANEEntities();
        [Authorize(Roles ="A")]
        public ActionResult Index()
        {
            var degerler = db.TBLHAREKET.Where(x =>x.ISLEMDURUM == false).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem>deger1 = (from x in db.TBLÜYELER.ToList()
                                          select new SelectListItem
                                          {
                                              Text=x.AD +" "+ x.SOYAD,
                                              Value = x.ID.ToString()
                                          }).ToList();

            List<SelectListItem> deger2 = (from x in db.TBLKİTAP.Where(x=>x.DURUM==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AD,
                                               Value = x.ID.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in db.TBLPERSONEL.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PERSONEL,
                                               Value = x.ID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TBLHAREKET o)
        {
            var d1 = db.TBLÜYELER.Where(x => x.ID == o.TBLÜYELER.ID).FirstOrDefault();
            var d2 = db.TBLKİTAP.Where(x => x.ID == o.TBLKİTAP.ID).FirstOrDefault();
            var d3 = db.TBLPERSONEL.Where(x => x.ID == o.TBLPERSONEL.ID).FirstOrDefault();
            o.TBLÜYELER = d1;
            o.TBLKİTAP = d2;
            o.TBLPERSONEL = d3;
            db.TBLHAREKET.Add(o);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Odunciade(TBLHAREKET p)
        {
            var odn =db.TBLHAREKET.Find(p.ID);
            DateTime d1 = DateTime.Parse(odn.IADETARIH.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;
            return View("Odunciade",odn);
        }
        public ActionResult OduncGuncelle(TBLHAREKET p)
        {
            var hrk = db.TBLHAREKET.Find(p.ID);
            hrk.UYEGETIRTARIH = p.UYEGETIRTARIH;
            hrk.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}