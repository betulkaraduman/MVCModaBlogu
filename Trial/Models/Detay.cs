using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trial.Models
{
    public class Detay
    {
        //public Detay()
        //{
        //   Markas = new HashSet<Marka>();
        //}

        [Key]

        public int DetayId { get; set; }
        public string DetayAciklama { get; set; }
     

    }
}