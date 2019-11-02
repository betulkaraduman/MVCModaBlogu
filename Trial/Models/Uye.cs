using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trial.Models
{


    public class Uye
    {


        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Boy  { get; set; }
        public int Kilo { get; set; }
        public int Yas { get; set; }
       

        // public ICollection<UyeYorum> uyeYorums { get; set; }

    }
}







































//    public class Uye
//    {

//        public Uye()
//        {
//            this.Markalars = new HashSet<Markalar>();
//        }


//        [Key]
//        public int UserId { get; set; }
//        public string Username { get; set; }
//        public string Name { get; set; }
//        public string Surname { get; set; }
//        public string Email { get; set; }
//        public string Password { get; set; }
//        public int Height { get; set; }
//        public int Weight { get; set; }
//        public int Age { get; set; }
//        //public ICollection<UyeYorum> uyeYorums { get; set; }

//        public virtual ICollection<Markalar> Markalars { get; set; }


//    }
//}