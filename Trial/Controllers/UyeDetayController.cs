using System.Linq;
using System.Web.Mvc;
using Trial.Models;

namespace Trial.Controllers
{
    public class UyeDetayController : Controller
    {

        OurDbContext db = new OurDbContext();
        // GET: MemberDetay
        public ActionResult Index()
        {
            return View();
        }
        //Kişi Göz ve Ten renk özelliği
      
        public ActionResult FizikselOzellik()
        {
            ViewBag.UserId = Session["UserId"];
            ViewBag.OzellikId = new SelectList(db.ozelliklerims, "OzellikId", "Ozellikler");
            return View();

        }
        [HttpPost]
        public ActionResult FizikselOzellik(DısOzellik dısOzellik, int?id)
        {
            if (ModelState.IsValid)
            {
                dısOzellik.UserId = (int)id;
                db.dısOzelliks.Add(dısOzellik);
                db.SaveChanges();
                return RedirectToAction("Index", "Member");
            }
            return View("Member/Index");
        }
        public ActionResult MarkaOlustur()
        {
            ViewBag.Username = Session["Username"];
            ViewBag.Name = Session["Name"];
            ViewBag.UserId1 = Session["UserId"];
            //ViewBag.UserId1 = new SelectList(db.markaMembers, Session["UserId"], "UserId");
            ViewBag.UserId = new SelectList(db.members, "USerId", "Username");
            ViewBag.MarkaId = new SelectList(db.markalars, "MarkaId", "MarkaAdi", "MarkaDetay");


            //  ViewBag.MarkaMemberId = new SelectList(db.markaMembers, "MarkaId", "UserId");
            return View();
        }

        [HttpPost]
        public ActionResult MarkaOlustur(MarkaMember markaMember,int?id)
        {

            if (ModelState.IsValid)
            {
                markaMember.UserId = (int)id;
                db.markaMembers.Add(markaMember);
                db.SaveChanges();
                return RedirectToAction("Index","Member");
            }

            return View(markaMember);
        }
        //public ActionResult Makyaj()
        //{
        //    ViewBag.UserId = Session["UserId"];
        //    ViewBag.CesitId = new SelectList(db.cesitMakyajs, "CesitId", "MakyajCesit");
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Makyaj(UyeMakyaj uyeMakyaj,int? id)

        //{
        //    if (ModelState.IsValid)
        //    {
        //        uyeMakyaj.UserId = (int)id;
        //        db.uyeMakyajs.Add(uyeMakyaj);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View("Index");
        //}

        public ActionResult MakyajOlustur()
        {

            ViewBag.UserId = Session["UserId"];
            ViewBag.CesitId = new SelectList(db.cesitMakyajs, "CesitId", "MakyajCesit");
            return View();

        }
        [HttpPost]
        public ActionResult Makyajolustur(UyeMakyaj uyeMakyaj,int?id)
        {
            if (ModelState.IsValid)
            {
                uyeMakyaj.UserId = (int)id;
                db.uyeMakyajs.Add(uyeMakyaj);
                db.SaveChanges();
                return RedirectToAction("Index", "Member");
            }
            return View("Index");
        }


        public ActionResult Begeni1(Trial.Models.Resimler resim, int? id)
        {

            ViewBag.UserId = id;
            return View(db.resimlers.ToList());
        }
        public ActionResult Begenim(int? UserId, UyeBegeni uyeBegeni, int? resimId)
        {
            OurDbContext db = new OurDbContext();
            if (ModelState.IsValid)
            {

                uyeBegeni.ResimId = (int)resimId;
                uyeBegeni.UserId = (int)UserId;
                db.uyeBegenis.Add(uyeBegeni);
                db.SaveChanges();

            }



            return RedirectToAction("Index", "Member");
        }

        public ActionResult Kisisellestir()
        {
            return View();
        }

        public ActionResult Markalar(int id)
        {
            return View(db.members.ToList());
        }

    
        
        //public ActionResult OzellikDetay(int? id, DısOzellik dısOzellik)
        //{
        //    ViewBag.UserId = Session["UserId"];
        //    return View(db.dısOzelliks.ToList());
        //}

      
        //public ActionResult Ozellik(int? id, Trial.Models.MarkaMember markaMember)
        //{
        //    ViewBag.UserId = Session["UserId"];
        //    var qwe = db.markaMembers.Where(x => x.UserId == id);
        //    var query = (from MarkaMember in db.markaMembers

        //                 join Markalar in db.markalars
        //                 on MarkaMember.MarkaId equals Markalar.MarkaId
        //                 join Uye in db.members
        //                 on MarkaMember.UserId equals Uye.UserId
        //                 select new MydataModel
        //                 {
        //                     MarkaAdi = Markalar.MarkaAdi,
        //                     MarkaDetay = Markalar.MarkaDetay,
        //                     MarkaResim = Markalar.MarkaResim,
        //                     UserId = Uye.UserId.ToString(),
        //                     MarkaOzel = Markalar.MarkaDetay


        //                 }).ToList();


        //    return View(query);

        //    //var query = (from MarkaMember in db.markaMembers
        //    //             join Markalar in db.markalars
        //    //             on MarkaMember.MarkaId equals Markalar.MarkaId
        //    //             join Uye in db.members
        //    //             on MarkaMember.UserId equals id
        //    //             select new MydataModel
        //    //             {
        //    //                 MarkaAdi = Markalar.MarkaAdi,
        //    //                 MarkaDetay = Markalar.MarkaDetay,
        //    //                 MarkaResim=Markalar.MarkaResim
        //    //             }).ToList();
        //    //return View(query.AsEnumerable());


        //    //var query = (from personel in db.Personeller
        //    //             join departman in db.Departmanlar
        //    //             on personel.DepartmanId equals departman.Id
        //    //             join gorev in db.Gorevler
        //    //             on personel.GorevId equals gorev.Id
        //    //             select new
        //    //             {
        //    //                 personel.Adi,
        //    //                 personel.Soyadi,
        //    //                 personel.Sonuc,
        //    //                 Departman = departman.Adi,
        //    //                 Gorevi = gorev.Gorev,
        //    //                 BaslangıcTarihi = gorev.Baslangic,
        //    //                 BitisTarihi = gorev.Bitis
        //    //             }).ToList();
        //    //return View(query);

        //}

        


        ////Beğnediği fotoğrafları getirme   
        //public ActionResult BegeniGetirme(int? id, Trial.Models.UyeBegeni uyeBegeni)
        //{
        //    ViewBag.UserId = Session["UserId"];
        //    var qwe = db.uyeBegenis.Where(x => x.UserId == id);
        //    var query = (from UyeBegeni in db.uyeBegenis
        //                 join Resimler in db.resimlers
        //                 on UyeBegeni.ResimId equals Resimler.ResimId
        //                 join Uye in db.members
        //                 on UyeBegeni.UserId equals Uye.UserId
        //                 select new UyeBegeniModel
        //                 {
        //                     Resim = Resimler.Image,
        //                     UserId = Uye.UserId.ToString()

        //                 }).ToList();
        
        //    return View(query);

        //}
        
    }
}