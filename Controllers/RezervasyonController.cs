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
        public ActionResult Index(TblRezervasyon p)
        {
            db.TblRezervasyon.Add(p);
            db.SaveChanges();
            return RedirectToAction("Rezervasyonlarim", "Misafir");
        }
    }
}