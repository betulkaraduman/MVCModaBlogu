using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trial.Models
{
    public class CesitMakyaj
    {

        [Key]
        public int CesitId { get; set; }
        public string MakyajCesit { get; set; }
        
        public string MakyajResim { get; set; }


        public string MakyajResim1 { get; set; }

        public string MakyajResim2 { get; set; }

        public string MakyajResim3 { get; set; }

        












    }
}