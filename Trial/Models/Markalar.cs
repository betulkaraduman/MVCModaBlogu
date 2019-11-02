using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trial.Models
{
    public class Markalar
    {
        

        [Key]
        public int MarkaId { get; set; }
        public string MarkaAdi { get; set; }

        public string MarkaDetay { get; set; }

        public string MarkaResim { get; set; }

        public string Foto1 { get; set; }

        public string Foto2 { get; set; }


        public string Logo { get; set; }



    }
}
//        public Markalar()
//        {
//            this.Uyes = new HashSet<Uye>();
//        }



//        [Key]
//        public int MarkaId { get; set; }
//        public string MarkaAdi { get; set; }

//        public string MarkaDetay { get; set; }

//        public string MarkaResim { get; set; }

//        public string Foto1 { get; set; } 

//        public string Foto2 { get; set; }


//        public string Logo { get; set; }
//       // public virtual ICollection uyeAccounts { get; set; }

//        public virtual ICollection<Uye> Uyes{ get; set; }




//    }
//}