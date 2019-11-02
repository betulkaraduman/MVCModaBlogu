using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trial.Models;
namespace Trial.Controllers
{
    public class MakyajController : Controller
    {
        OurDbContext db = new OurDbContext();
        // GET: Makyaj

        public ActionResult Index1()
        {
            return View(db.urunlers.ToList());
        }
        //Malzemelerin detayları
        public ActionResult Detay1(int id)
        {
            OurDbContext db = new OurDbContext();
            return View(db.urunlers.Find(id));
        }

    

    }
}