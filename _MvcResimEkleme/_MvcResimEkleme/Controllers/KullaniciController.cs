using _MvcResimEkleme.Ayar;
using _MvcResimEkleme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _MvcResimEkleme.Controllers
{
    //[_SecurityFilter]
    public class KullaniciController : Controller
    {
        MvcContext db = new MvcContext();

        // GET: Kullanici 
        //[_SecurityFilter]
        public ActionResult Index()
        {
            var kullanicilar = db.Kullanici.ToList();
            return View(kullanicilar);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            ViewBag.yetkiID = new SelectList(db.Yetki, "yetkiID", "ad");
            ViewBag.fakulteID = new SelectList(db.Birim.Where(x=>x.ustID==null), "birimID", "ad").ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Kullanici k, HttpPostedFileBase resim2)
        {
            Dosya dosya = new Dosya();
            string resimAdi = dosya.resimYukle(resim2);
            if(resimAdi =="uzanti")
            {
                ViewBag.Sonuc = "Lütfen .png veya .jpg uzantılı resim giriniz.";
                ViewBag.yetkiID = new SelectList(db.Yetki, "yetkiID", "ad");
                return View();
            }
            else if(resimAdi == "boyut")
            {
                ViewBag.Sonuc = "Lütfen 1MB dan fazla boyutta resim yükleyiniz.";
                ViewBag.yetkiID = new SelectList(db.Yetki, "yetkiID", "ad");
                return View();
            }
            k.resim = resimAdi;
            db.Kullanici.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public JsonResult BolumGetir(int id)
        {
            List<SelectListItem> bolumler = new List<SelectListItem>();
            var ilceData = db.Birim.Where(x=> x.ustID==id).Select(x => new SelectListItem()
            {
                Text = x.ad,
                Value = x.birimID.ToString(),
            });
            return Json(ilceData, JsonRequestBehavior.AllowGet);
        }
    }
}