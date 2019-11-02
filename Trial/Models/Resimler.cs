using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trial.Models
{
    public class Resimler
    {
        [Key]
        public int  ResimId { get; set; }
        public string Image { get; set; }
        public string ResimKategorisi { get; set; }
        public string ımage2 { get; set; }

    }
}