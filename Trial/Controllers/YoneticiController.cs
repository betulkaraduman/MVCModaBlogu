using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trial.Models;
using System.Web.Mvc;
using System.Web.Helpers;
using System.IO;
namespace Trial.Controllers
{
    public class YoneticiController : Controller
    {
        OurDbContext db = new OurDbContext();
        // GET: Yonetici
        public ActionResult Index()
        {
            var fotograf = db.kategoriResims.ToList();
            return View(fotograf);
        }
        //Fiziksel özellik
        public ActionResult F_Ozellik()
        {
            ViewBag.OzellikId = new SelectList(db.ozelliklerims, "OzellikId", "Ozellikler");
            return View();
        }

        [HttpPost]
        public ActionResult F_Ozellik(Ozelliklerim ozelliklerim)
        {
            if(ModelState.IsValid)
            {
                db.ozelliklerims.Add(ozelliklerim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ozelliklerim);
        }

    
        public ActionResult FizikselOzellik()
        {
            ViewBag.OzellikId = new SelectList(db.ozelliklerims, "OzellikId", "Ozellikler");
            return View();
        }
        [HttpPost]
        public ActionResult FizikselOzellik(Ozelliklerim ozelliklerim)

        {
            if (ModelState.IsValid)
            {
                db.ozelliklerims.Add(ozelliklerim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ozelliklerim);
        }





        //public ActionResult Ozelligim()
        //{
        //    ViewBag.Id = new SelectList(db.ozelliklerims, "Id", "Ozellikler");
        //    return View();

        //}
        //[HttpPost]
        //public ActionResult Ozelligim(Ozelliklerim ozelliklerim)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        db.ozelliklerims.Add(ozelliklerim);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(ozelliklerim);
        //}

        ////Fiziksel özellik
        //public ActionResult Ozellik()
        //{
        //    ViewBag.Id = new SelectList(db.ozelliğis, "Id", "TenRengi");
        //    ViewBag.Id1 = new SelectList(db.ozelliğis, "Id", "GozRengi");
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Ozellik(ozelliği ozelliği)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        db.ozelliğis.Add(ozelliği);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(ozelliği);
        //}



        public ActionResult KategoriListe()
        {
            return View(db.kategoris.ToList());
        }









        //Markaekle
        public ActionResult MarkaEkle()
            {
                ViewBag.MarkaId = new SelectList(db.markalars, "MarkaId", "MarkaAdi","MarkaDetay");
                return View();
            }
            [HttpPost]
       
        public ActionResult MarkaEkle(Markalar markas ,HttpPostedFileBase foto, HttpPostedFileBase foto1, HttpPostedFileBase foto2, HttpPostedFileBase Logo, string Etiket)

            {
                if (ModelState.IsValid)
                {
                 if (foto != null)
                {
                    WebImage img = new WebImage(foto.InputStream);
                    FileInfo fotoinfo = new FileInfo(foto.FileName);

                    string yenifoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(800, 350);
                    img.Save("~/Uploads/Resimler/" + yenifoto);
                    markas.MarkaResim = "/Uploads/Resimler/" + yenifoto;
                }

                 if (foto1 != null)
                {
                    WebImage img = new WebImage(foto1.InputStream);
                    FileInfo fotoinfo = new FileInfo(foto1.FileName);

                    string yenifoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(800, 350);
                    img.Save("~/Uploads/Resimler/" + yenifoto);
                    markas.Foto1 = "/Uploads/Resimler/" + yenifoto;


                }

                if (foto2 != null)
                {
                    WebImage img = new WebImage(foto2.InputStream);
                    FileInfo fotoinfo = new FileInfo(foto2.FileName);

                    string yenifoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(800, 350);
                    img.Save("~/Uploads/Resimler/" + yenifoto);
                    markas.Foto2 = "/Uploads/Resimler/" + yenifoto;


                }
                if (Logo != null)
                {
                    WebImage img = new WebImage(Logo.InputStream);
                    FileInfo fotoinfo = new FileInfo(Logo.FileName);

                    string yenifoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(800, 350);
                    img.Save("~/Uploads/Resimler/" + yenifoto);
                    markas.Logo = "/Uploads/Resimler/" + yenifoto;


                }

                       db.markalars.Add(markas);

                       db.SaveChanges();
                       return RedirectToAction("Index");
                   }
                   return View(markas);



               }

       
        //Ana ekran fotografları ekle
        public ActionResult FotografEkle()
        {
            ViewBag.ResimId = new SelectList(db.resimlers, "ResimId");
            return View();
        }

        [HttpPost]
        public ActionResult FotografEkle(Resimler resimler, HttpPostedFileBase foto, HttpPostedFileBase foto2)
        {
            if (ModelState.IsValid)
            {
                if (foto != null)
                {
                    WebImage img = new WebImage(foto.InputStream);
                    FileInfo fotoinfo = new FileInfo(foto.FileName);
                    string yenifoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(800, 350);
                    img.Save("~/Uploads/Resimler/" + yenifoto);
                    resimler.Image = "/Uploads/Resimler/" + yenifoto;
                }
                if (foto2 != null)
                {
                    WebImage img = new WebImage(foto2.InputStream);
                    FileInfo fotoinfo = new FileInfo(foto2.FileName);
                    string yenifoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(800, 350);
                    img.Save("~/Uploads/Resimler/" + yenifoto);
                    resimler.ımage2 = "/Uploads/Resimler/" + yenifoto;

                }


                db.resimlers.Add(resimler);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(resimler);

        }



        //Makyaj türü ekle
        public ActionResult MakyajEkle()
        {
            ViewBag.CesitId = new SelectList(db.cesitMakyajs, "CesitId", "MakyajCesit ");
            return View();
        }
        [HttpPost]
        public ActionResult MakyajEkle(CesitMakyaj cesitMakyaj, HttpPostedFileBase foto, HttpPostedFileBase foto1, HttpPostedFileBase foto2, HttpPostedFileBase foto3)

        {
            if (ModelState.IsValid)
            {
                if (foto != null)
                {
                    WebImage img = new WebImage(foto.InputStream);
                    FileInfo fotoinfo = new FileInfo(foto.FileName);

                    string yenifoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(800, 350);
                    img.Save("~/Uploads/Resimler/" + yenifoto);
                    cesitMakyaj.MakyajResim = "/Uploads/Resimler/" + yenifoto;
                }

                if (foto1 != null)
                {
                    WebImage img = new WebImage(foto1.InputStream);
                    FileInfo fotoinfo = new FileInfo(foto1.FileName);

                    string yenifoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(800, 350);
                    img.Save("~/Uploads/Resimler/" + yenifoto);
                    cesitMakyaj.MakyajResim1 = "/Uploads/Resimler/" + yenifoto;


                }

                if (foto2 != null)
                {
                    WebImage img = new WebImage(foto2.InputStream);
                    FileInfo fotoinfo = new FileInfo(foto2.FileName);

                    string yenifoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(800, 350);
                    img.Save("~/Uploads/Resimler/" + yenifoto);
                    cesitMakyaj.MakyajResim2 = "/Uploads/Resimler/" + yenifoto;


                }

                if (foto3 != null)
                {
                    WebImage img = new WebImage(foto3.InputStream);
                    FileInfo fotoinfo = new FileInfo(foto3.FileName);

                    string yenifoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(800, 350);
                    img.Save("~/Uploads/Resimler/" + yenifoto);
                    cesitMakyaj.MakyajResim3 = "/Uploads/Resimler/" + yenifoto;


                }
                db.cesitMakyajs.Add(cesitMakyaj);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cesitMakyaj);

        }






        //Makyaj malzemesi ekle
        public ActionResult UrunEkle()
        {
            ViewBag.UrunId = new SelectList(db.urunlers, "UrunId", "UrunAdi", "UrunMetin");
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urunler urunler, HttpPostedFileBase foto)
        {
            if (ModelState.IsValid)
            {
                if (foto != null)
                {
                    WebImage img = new WebImage(foto.InputStream);
                    FileInfo fotoinfo = new FileInfo(foto.FileName);
                    string yenifoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
                    img.Resize(800, 350);
                    img.Save("~/Uploads/Resimler/" + yenifoto);
                    urunler.UrunResmi = "/Uploads/Resimler/" + yenifoto;
                }


                db.urunlers.Add(urunler);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(urunler);

        }



        //Kayıt
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayit(Trial.Models.Yonetici yonetici)
        {
            if (ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {
                    db.yoneticis.Add(yonetici);
                    db.SaveChanges();
                }
                ModelState.Clear();

            }
            return View();
        }


        //Giriş
        public ActionResult Giris()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Giris(Trial.Models.Yonetici yonetici)
        {
            using (OurDbContext db = new OurDbContext())

            {
                var usr = db.yoneticis.Single(u => u.Username == yonetici.Username && u.Password == yonetici.Password);
                if (usr != null)
                {
                    Session["UserId"] = yonetici.UserId.ToString();
                    Session["Username"] = yonetici.Username.ToString();
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Kullanıcı Adı veya sifre hatalı");

            }

            return View();

        }
        
    }

}









