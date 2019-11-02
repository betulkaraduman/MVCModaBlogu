using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trial.Models
{
    public class UyeMakyaj
    {

        [Key]
        public int Id { get; set; }
        [ForeignKey("CesitId")]
        public CesitMakyaj Cesitmakyaj { get; set; }
        public int CesitId { get; set; }
        [ForeignKey("UserId")]
        public Uye member { get; set; }
        public int UserId { get; set; }

    }
}