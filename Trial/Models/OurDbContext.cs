using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Data.Entity;

namespace Trial.Models
{
    public class OurDbContext:DbContext
    {
        public OurDbContext() : base("Completion")
        {
            Database.SetInitializer<OurDbContext>(new DropCreateDatabaseIfModelChanges<OurDbContext>());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
         
            modelBuilder.Entity<Etiket>()
                .HasMany(e => e.KategoriResims)
                .WithMany(e => e.etikets)
                .Map(m => m.ToTable("KategoriResimEtiket").MapLeftKey("EtiketId").MapRightKey("KategoriResimId"));

            


            base.OnModelCreating(modelBuilder);

         



        }
        public DbSet<UyeMakyaj> uyeMakyajs { get; set; }
        public DbSet<CesitMakyaj> cesitMakyajs { get; set; }
        public DbSet<Ozelliklerim> ozelliklerims { get; set; }
        public DbSet<DısOzellik> dısOzelliks { get; set; }
        public DbSet<ozelliği> ozelliğis { get; set; }
        public DbSet<OzellikUye> ozellikUyes { get; set; }
        public DbSet<Markalar> markalars { get; set; }
        public DbSet<Uye> members { get; set; }
        public DbSet<MarkaMember> markaMembers { get; set; }
        public DbSet<YorumPuan> yorumPuans { get; set; }
        public DbSet<Urunler> urunlers { get; set; }
       
        public DbSet<Detay> Detays { get; set; }
        public DbSet<Yonetici> yoneticis { get; set; }
        public DbSet<Kategori> kategoris { get; set; }
        public DbSet<UyeYorum> uyeYorums { get; set;}
        public DbSet<KategoriResim> kategoriResims { get; set; }
        public DbSet<Resimler> resimlers { get; set; }
        public DbSet<UyeBegeni> uyeBegenis { get; set; }
        public DbSet<Etiket> etikets { get; set; }







    }
}