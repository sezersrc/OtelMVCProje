using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelMVCProje.Models.Entity;

namespace OtelMVCProje.Controllers
{
    public class MisafirController : Controller
    {
        // GET: Misafir

        private DbOtelDevExEntities db = new DbOtelDevExEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rezervasyonlarim()
        {
            var misafirmail = (string)Session["Mail"];
            ViewBag.deger = misafirmail;

            var degerler = db.TblRezervasyon.Where(x => x.Misafir == 2).ToList();
            return View(degerler);
        }
    }
}