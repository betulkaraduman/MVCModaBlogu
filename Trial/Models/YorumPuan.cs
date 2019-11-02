using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trial.Models
{
    public class YorumPuan
    {
        [Key]
        public int PuanId { get; set; }

        public int UyePuan { get; set; }


        [ForeignKey("YorumId")]
        public UyeYorum UyeYorum{ get; set; }

        public int YorumId { get; set; }




    }


}