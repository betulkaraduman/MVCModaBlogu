using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trial.Models;
namespace Trial.Controllers
{
    public class MarkalarController : Controller
    {
        OurDbContext db = new OurDbContext();
        // GET: Markalar
        public ActionResult Index()
        {
            return View(db.markalars.ToList());
        }


        public ActionResult Anasayfa()
        {
            return View();
        }

        public ActionResult denem()
        {
            return View(db.markalars.ToList());
        }


        public ActionResult Detay(int id)
        {
            OurDbContext db = new OurDbContext();
            return View(db.markalars.Find(id));
            
        }

        
        public ActionResult Detayım(int id)
        {
            OurDbContext db = new OurDbContext();
            
            return View(db.markalars.Find(id));
        }

        public ActionResult MarkaDetay2(int id)
        {
            var model = db.Detays.Find(id);
            if(model==null)
           return HttpNotFound();
            return View(model);
        }

    }
}