using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OtelMVCProje.Models.Entity;

namespace OtelMVCProje.Controllers
{
    [Authorize]
    public class MisafirController : Controller
    {
        // GET: Misafir

        private DbOtelDevExEntities db = new DbOtelDevExEntities();
        public ActionResult Index()
        {
            var misafirmail = (string)Session["Mail"];
            var misafirbilgi = db.TblWebKayit.Where(x => x.Mail == misafirmail).FirstOrDefault();
            return View(misafirbilgi);
        }

        public ActionResult Rezervasyonlarim()
        {
            var misafirmail = (string)Session["Mail"];
            var misafirid = db.TblWebKayit.Where(x => x.Mail == misafirmail).Select(y => y.ID).FirstOrDefault();
            var degerler = db.TblRezervasyon.Where(x => x.Misafir == misafirid).ToList();
            return View(degerler);
        }

        public ActionResult MisafirBilgiGuncelle(TblWebKayit p)
        {
            var misafir = db.TblWebKayit.Find(p.ID);
            misafir.AdSoyad = p.AdSoyad;
            misafir.Telefon = p.Telefon;
            misafir.Sifre = p.Sifre;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Anasayfa");
        }

        public ActionResult GelenMesajlar()
        {
            var misafirmail = (string)Session["Mail"];
            var mesajlar = db.TblMesajAdmin.Where(x => x.Alici ==misafirmail).ToList();
            return View(mesajlar);
        }

        public ActionResult GidenMesajlar()
        {
            var misafirmail = (string)Session["Mail"];
            var mesajlar = db.TblMesajAdmin.Where(x => x.Gonderen == misafirmail).ToList();
            return View(mesajlar);
        }

        public ActionResult MesajDetay(int id)
        {
            var mesaj = db.TblMesajAdmin.Where(x => x.MesajID == id).FirstOrDefault();
            return View(mesaj);
        }
    }
}