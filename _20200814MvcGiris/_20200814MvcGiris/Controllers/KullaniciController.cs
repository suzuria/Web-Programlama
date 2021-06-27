using _20200814MvcGiris.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _20200814MvcGiris.Controllers
{
    public class KullaniciController : Controller
    {
        // Veritabanı işlemlerini yapacak nesne global tanımlanır
        MvcGirisContext db = new MvcGirisContext();

        public ActionResult Index()
        {            
            return View(db.Kullanici.ToList());
            //var kullanicilar = db.Kullanici.ToList();
            //return View(kullanicilar);
        }

        public ActionResult Ekle()
        {
            return View();
        }
    }
}