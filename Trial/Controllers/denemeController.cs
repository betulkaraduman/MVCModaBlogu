using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trial.Models;

namespace Trial.Controllers
{
    public class denemeController : Controller
    {
        OurDbContext db = new OurDbContext();
        // GET: deneme
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
        public ActionResult denemee()
        {
            return View();
        }
    }
}