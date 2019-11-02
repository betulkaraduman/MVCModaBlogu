using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trial.Models
{
    public class DısOzellik
    {
        public int DısOzellikId { get; set; }

        [ForeignKey("OzellikId")]
        public Ozelliklerim ozelliklerim { get; set; }
        public int OzellikId { get; set; }

        

        [ForeignKey("UserId")]
        public Uye Uye { get; set; }
        public int UserId { get; set; }



    }
}