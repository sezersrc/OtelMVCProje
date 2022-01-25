using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using OtelMVCProje.Models.Entity;

namespace OtelMVCProje.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        private DbOtelDevExEntities db = new DbOtelDevExEntities();
       public ActionResult Hakkimda()
       {
           var veriler = db.TblHakkimda.ToList();
            return View(veriler);
        }
       


        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        public PartialViewResult PartialSosyalMedya()
        {
            return PartialView();
        }

    }
}