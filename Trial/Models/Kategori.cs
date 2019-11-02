using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trial.Models
{
    public class Kategori
    {

        [Key]
        public int KategoriId { get; set; }
        public string KategoriAdi{ get; set; }

        public ICollection <KategoriResim> kategoriResims { get; set; }

        



    }
}