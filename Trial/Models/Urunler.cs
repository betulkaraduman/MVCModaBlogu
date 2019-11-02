using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trial.Models
{
    public class Urunler
    {[Key]
        public int UrunId { get; set; }

        public string UrunAdi { get; set; }
        public string UrunResmi { get; set; }
        public string UrunMetin { get; set; }

       



    }
}