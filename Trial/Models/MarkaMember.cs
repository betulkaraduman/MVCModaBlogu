using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trial.Models
{
    public class MarkaMember
    {
        
            [Key]
            public int Id { get; set; }
            [ForeignKey("MarkaId")]
            public Markalar markalar { get; set; }
            public int MarkaId { get; set; }
            [ForeignKey("UserId")]
            public Uye member { get; set; }
            public int UserId { get; set; }
        








    }
}