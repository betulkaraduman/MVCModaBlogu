using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trial.Models;

namespace Trial.Controllers
{
    public class HomeController : Controller
    {
        OurDbContext db = new OurDbContext();
        // GET: Home
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult anasayfa()
        {
            return View();
        }





        public ActionResult Fotograflar(string searching)
        {
            var resim = from s in db.resimlers
                        select s;
            if (!string.IsNullOrEmpty(searching))
            {
                resim = resim.Where(s => s.ResimKategorisi.Contains(searching));
            }

            return View(resim.ToList());
        }
        public ActionResult Index(string searching)
        {
            var resim = from s in db.resimlers
                        select s;
            if (!string.IsNullOrEmpty(searching))
            {
                resim = resim.Where(s => s.ResimKategorisi.Contains(searching));
            }

            return View(resim.ToList());
        }




        public ActionResult ındex2()
        {
            return View();
        }

    }
}