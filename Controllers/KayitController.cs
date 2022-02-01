using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelMVCProje.Models.Entity;

namespace OtelMVCProje.Controllers
{
    public class KayitController : Controller
    {
        // GET: Kayit

        private DbOtelDevExEntities db = new DbOtelDevExEntities();
        [HttpGet]
        public ActionResult KayitOl()
        {
            return View();
        }
        public ActionResult Index()
        {
            return Content(Sifrele.MD5Olustur("123"));
        }

        [HttpPost]
        public ActionResult KayitOl(TblWebKayit p)
        {
            
            db.TblWebKayit.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index","Login");
        }
    }
}