using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trial.Models
{
    public class UyeBegeni
    {
        [Key]
        public int UyeBegeniId { get; set; }

        [ForeignKey("UserId")]
        public Uye  uye { get; set; }

        public int UserId { get; set; }
        [ForeignKey("ResimId")]
        public Resimler resimler { get; set; }

        public int ResimId { get; set; }

}
}