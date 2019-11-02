using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trial.Models
{
    public class OzellikUye
    {
          [Key]   
        public int OzellikUyeId { get; set; }
        [ForeignKey("Id")]
        public ozelliği ozelliği { get; set; }
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public Uye uyes { get; set; }
        public int UserId { get; set; }

    }

}