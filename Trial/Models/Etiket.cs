using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trial.Models
{
    public class Etiket
    {
        public Etiket()
        {
            KategoriResims = new HashSet<KategoriResim>();
        }


        [Key]
        public int EtiketId { get; set; }

        public string EtiketAdi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage","CA2227:CollectionPropertiesShouldBeReadOnly  ")]
        public virtual ICollection<KategoriResim> KategoriResims { get; set; }

    }
}