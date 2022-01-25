using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelMVCProje.Models.Entity;

namespace OtelMVCProje.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        private DbOtelDevExEntities db = new DbOtelDevExEntities();
        public ActionResult Index()
        {
            var bilgiler = db.TblIletisim.ToList();
            return View(bilgiler);
        }
        [HttpGet]
        public PartialViewResult MesajGonder()
        {

            return PartialView();
        }
        [HttpPost]
        public PartialViewResult MesajGonder(TblMesaj p)
        {
            db.TblMesaj.Add(p);
            db.SaveChanges();
            return PartialView();
        }
    }
}