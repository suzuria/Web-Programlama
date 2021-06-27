using _MvcResimEkleme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _MvcResimEkleme.Controllers
{
    public class LoginController : Controller
    {
        MvcContext db = new MvcContext();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string eposta, string sifre)
        {
            Kullanici k = db.Kullanici.Where(x => x.eposta == eposta && x.sifre == sifre).SingleOrDefault();
            if (k == null)
            {
                ViewBag.Sonuc = "Eposta veya şifre hatalı";
                return View();
                //Kullanıcı bulunamadı
            }
            else
            {
                Session["Kullanici"] = k;
                return Redirect("/Kullanici/Ekle");
                // kullanıcı bulundu.
            }
        }
    }
}