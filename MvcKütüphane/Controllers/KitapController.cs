﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKütüphane.Controllers;
using MvcKütüphane.Models.Entity;

namespace MvcKütüphane.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        DBKÜTÜPHANEEntities db = new DBKÜTÜPHANEEntities();
        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.TBLKİTAP select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(x => x.AD.Contains(p));
            }
            //var kitaplar = db.TBLKİTAP.ToList();
            return View(kitaplar.ToList());
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TBLKATEGORİ.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TBLYAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TBLKİTAP p)
        {
            var ktg = db.TBLKATEGORİ.Where(k => k.ID == p.TBLKATEGORİ.ID).FirstOrDefault();
            var yzr = db.TBLYAZAR.Where(y => y.ID == p.TBLYAZAR.ID).FirstOrDefault();
            p.TBLKATEGORİ =ktg;
            p.TBLYAZAR = yzr;
            db.TBLKİTAP.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapSil(int id)
        {
            var kitap = db.TBLKİTAP.Find(id);
            db.TBLKİTAP.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapGetir(int id)
        {
            var ktp = db.TBLKİTAP.Find(id);
            List<SelectListItem> deger1 = (from i in db.TBLKATEGORİ.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from i in db.TBLYAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            ViewBag.dgr1 = deger1;
            return View("KitapGetir", ktp);
        }
        public ActionResult KitapGüncelle(TBLKİTAP p)
        {
            var kitap = db.TBLKİTAP.Find(p.ID);
            kitap.AD = p.AD;
            kitap.BASIMYIL = p.BASIMYIL;
            kitap.SAYFA = p.SAYFA;
            kitap.YAYINEVİ = p.YAYINEVİ;
            kitap.DURUM = true;
            var ktg = db.TBLKATEGORİ.Where(k =>k.ID == p.TBLKATEGORİ.ID).FirstOrDefault();
            var yzr = db.TBLYAZAR.Where(y => y.ID == p.TBLYAZAR.ID).FirstOrDefault();
            kitap.KATEGORİ = ktg.ID;
            kitap.YAZAR = yzr.ID;
            kitap.KITAPRESIM = p.KITAPRESIM;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}