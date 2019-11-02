using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trial.Models
{
    public class Ozelliklerim
    {
        [Key]
        public int OzellikId { get; set; }
        public string Ozellikler { get; set; }

    }
}