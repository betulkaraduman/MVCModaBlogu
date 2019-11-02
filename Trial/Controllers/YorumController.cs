using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Linq;
using System.Net;
using Trial.Models;

using System.Web.Mvc;
using System.IO;
using System.Text;


namespace Trial.Controllers
{
    public class YorumController : Controller
    {
        OurDbContext db = new OurDbContext();
        // GET: Yorum
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult YorumListele()
        {
            OurDbContext db = new OurDbContext();
            ViewModel vm = new ViewModel();
            vm.uyeYorums = db.uyeYorums.ToList();
            vm.yorumPuans = db.yorumPuans.ToList();


            return View(vm);
        }

        
        public ActionResult YorumListele1(int? id, Trial.Models.YorumPuan u, UyeYorum uyeYorum, int? Yid)
        {
            var s = db.yorumPuans.FirstOrDefault(x => x.YorumId == Yid);
            if (s != null)
            {
                s.YorumId = (int)Yid;
                s.UyePuan += 1;
                db.Entry(s).State = EntityState.Modified;
                db.SaveChanges();
                return View("Index", db.yorumPuans);
            }
            else
            {
                db.yorumPuans.Add(u);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
    }
}