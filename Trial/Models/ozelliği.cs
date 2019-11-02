using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trial.Models
{
    public class ozelliği
    {
        [Key]
        public int Id { get; set; }

       public string TenRengi { get; set; }

        public string GozRengi { get; set; }

    }
}