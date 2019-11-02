using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trial.Models
{
    public class UyeYorum
    {
        [Key]
        public int YorumId { get; set; }
   
        public string Yorum { get; set; }
    
        [ForeignKey("UserId")]
        public Uye uyes { get; set; }

        public int UserId { get; set; }



    }
}