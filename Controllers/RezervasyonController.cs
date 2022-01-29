using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelMVCProje.Models.Entity;

namespace OtelMVCProje.Controllers
{
    public class RezervasyonController : Controller
    {
        // GET: Rezervasyon
        private DbOtelDevExEntities db = new DbOtelDevExEntities();


        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblOnRezervasyon p)
        {
            var misafirmail = (string)Session["Mail"];
            //var misafirid = db.TblWebKayit.Where(x => x.Mail == misafirmail).Select(x=>x.ID).FirstOrDefault();

            //p.Durum = 14;
            //p.Misafir = misafirid;
            p.Mail = misafirmail;
            p.Tarih=DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblOnRezervasyon.Add(p);
            db.SaveChanges();
            return RedirectToAction("Rezervasyonlarim", "Misafir");
        }
    }
}