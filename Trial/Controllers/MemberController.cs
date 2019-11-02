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
    public class MemberController : Controller
    {
        // GET: Member
        OurDbContext db = new OurDbContext();
        
        public ActionResult Index()
        {
            return View(db.resimlers.ToList());
        }


        public ActionResult Cıkıs()
        {
            return RedirectToAction("anasayfa","home");
        }

             
        public ActionResult Index2()
        {
            return View(db.resimlers.ToList());
        }
        
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Trial.Models.Uye members)
        {
            if (ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {
                    db.members.Add(members);
                    db.SaveChanges();
                }

                ModelState.Clear();

            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Trial.Models.Uye member,Trial.Models.Resimler resimler)
        {
            using (OurDbContext db = new OurDbContext())
            {
                
                var usr = db.members.Single(u => u.Username == member.Username && u.Password == member.Password);
                if (usr != null)
                {
                    
                    Session["UserId"] = usr.UserId.ToString();
                    Session["UserName"] = usr.Username.ToString();
                    Session["Boy"] = usr.Boy;
                    Session["Yas"] = usr.Yas;
                    Session["Kilo"] = usr.Kilo;
                    Session["Name"] = usr.Name.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
                }
            }
            return View();
        }


        public ActionResult YorumEkle(int id)
        {
            ViewBag.UserId = id;
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult YorumEkle(Trial.Models.UyeYorum ekle, Trial.Models.Uye uye)
        {
            OurDbContext db = new OurDbContext();
            db.uyeYorums.Add(ekle);
            db.SaveChanges();

            YorumPuan yp = new YorumPuan();
            yp.UyePuan = 0;
            yp.YorumId = ekle.YorumId;

            db.yorumPuans.Add(yp);
            db.SaveChanges();
           
           return RedirectToAction("Index");
        }
        
    
        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Register");
            }
        }

        public ActionResult Guncelle(int id)
        {
            return View("Guncelle", db.members.Find(id));
        }

        [HttpPost]
        public ActionResult Guncelle(Uye u)
        {
            var mevcut = db.members.Find(u.UserId);
            mevcut.Username = u.Username;

            mevcut.Name = u.Name;
            mevcut.Surname = u.Surname;
            mevcut.Email = u.Email;
            mevcut.Password = u.Password;
            mevcut.Boy = u.Boy;
            mevcut.Kilo = u.Kilo;
            mevcut.Yas = u.Yas;

            db.SaveChanges();
            return View("Index");
        }

        //public ActionResult YorumEkle(string yorum,int UserId)
        //{
        //    ViewBag.YorumEkle = new SelectList(db.uyeYorums.ToList(), "id");

        //    return View(db.uyeYorums.Find());
        //}

        //[HttpPost]
        //public ActionResult YorumEkle(UyeYorum yorum, HttpPostedFile upfile)
        //{



        //    return View();


        //}

        //public ActionResult YorumuEkle(int id)
        //{
        //    ViewBag.UserId = id;
        //    return View();
        //}
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Uye member = db.members.Find(id);

        //    if (member == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(member);
        //}

        //[HttpPost]
        //public ActionResult Edit([Bind(Include = "Username,Name,Surname,Email,Password,Height,Weight,Age")] Uye members)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(members).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(members);
        //}


        //public ActionResult Bilinmez(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Uye uye = db.members.Find(id);
        //    if (uye == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(uye);
        //}
        //[HttpPost]

        public ActionResult Markalistele()
        {
            return View(db.markalars.ToList());
        }
      
        //Kişi özelliklerinin detayları (Göz ve ten rengi)  
        public ActionResult OzellikDetay(int? id,DısOzellik dısOzellik)
        {
            ViewBag.UserId = Session["UserId"];
            return View(db.dısOzelliks.ToList());
        }
        
     
        //Seçtiği marka özelliklerini çekme
        public ActionResult Ozellik(int? id, Trial.Models.MarkaMember markaMember)
        {
            ViewBag.UserId = Session["UserId"];
            var qwe = db.markaMembers.Where(x => x.UserId == id);
            var query = (from MarkaMember in db.markaMembers

                         join Markalar in db.markalars
                         on MarkaMember.MarkaId equals Markalar.MarkaId
                         join Uye in db.members
                         on MarkaMember.UserId equals Uye.UserId
                         select new MydataModel
                         {
                             MarkaAdi = Markalar.MarkaAdi,
                             MarkaDetay = Markalar.MarkaDetay,
                             MarkaResim = Markalar.MarkaResim,
                             UserId = Uye.UserId.ToString(),
                             MarkaOzel = Markalar.MarkaDetay,
                             Foto1=Markalar.Foto1,
                             Foto2=Markalar.Foto2,
                             Logo=Markalar.Logo
                             
                         }).ToList();


            return View(query);

            //var query = (from MarkaMember in db.markaMembers
            //             join Markalar in db.markalars
            //             on MarkaMember.MarkaId equals Markalar.MarkaId
            //             join Uye in db.members
            //             on MarkaMember.UserId equals id
            //             select new MydataModel
            //             {
            //                 MarkaAdi = Markalar.MarkaAdi,
            //                 MarkaDetay = Markalar.MarkaDetay,
            //                 MarkaResim=Markalar.MarkaResim
            //             }).ToList();
            //return View(query.AsEnumerable());


            //var query = (from personel in db.Personeller
            //             join departman in db.Departmanlar
            //             on personel.DepartmanId equals departman.Id
            //             join gorev in db.Gorevler
            //             on personel.GorevId equals gorev.Id
            //             select new
            //             {
            //                 personel.Adi,
            //                 personel.Soyadi,
            //                 personel.Sonuc,
            //                 Departman = departman.Adi,
            //                 Gorevi = gorev.Gorev,
            //                 BaslangıcTarihi = gorev.Baslangic,
            //                 BitisTarihi = gorev.Bitis
            //             }).ToList();
            //return View(query);

        }
        
        //Uye Fotoğraf beğenme
        public ActionResult Begeni(Trial.Models.Resimler resim, int? id ,string searching)
        {
            ViewBag.UserId = id;
            var resimim = from s in db.resimlers
                        select s;
            if (!string.IsNullOrEmpty(searching))
            {
                resimim = resimim.Where(s => s.ResimKategorisi.Contains(searching));
            }

            return View(resimim.ToList());
        }

        public ActionResult Begenim(int? UserId, UyeBegeni uyeBegeni, int? resimId)
        {
            //id1 = 1;
            // id = 1;

            OurDbContext db = new OurDbContext();
            if (ModelState.IsValid)
            {

                uyeBegeni.ResimId = (int)resimId;
                uyeBegeni.UserId = (int)UserId;
                db.uyeBegenis.Add(uyeBegeni);
                db.SaveChanges();

            }


            return View("Guncelle");
        }
        
        //Beğnediği fotoğrafları getirme   
        public ActionResult BegeniGetirme(int? id,Trial.Models.UyeBegeni uyeBegeni,string searching)
       {
            ViewBag.UserId = Session["UserId"];
            var qwe = db.uyeBegenis.Where(x => x.UserId == id);
            var query = (from UyeBegeni in db.uyeBegenis
                         join Resimler in db.resimlers
                         on UyeBegeni.ResimId equals Resimler.ResimId
                         join Uye in db.members
                         on UyeBegeni.UserId equals Uye.UserId
                         select new UyeBegeniModel
                         {
                             Resim=Resimler.Image,
                             UserId=Uye.UserId.ToString()

                         }).ToList();
            
            return View(query);

        }
        
    }

}