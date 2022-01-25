using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OtelMVCProje.Models.Entity;

namespace OtelMVCProje.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        private DbOtelDevExEntities db = new DbOtelDevExEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblWebKayit p)
        {
            var bilgiler = db.TblWebKayit.FirstOrDefault(x => x.Mail == p.Mail && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Mail,false);
                Session["Mail"] = bilgiler.Mail.ToString();

                return RedirectToAction("Index","Misafir");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}