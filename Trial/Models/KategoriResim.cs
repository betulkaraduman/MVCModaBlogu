using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trial.Models
{
    public class KategoriResim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly  ")]

        public KategoriResim()
        {
            etikets = new HashSet<Etiket>();
        }




        [Key]
        public int KategoriResimId { get; set; }

        public string KategoriResmi { get; set; }
        public int? KategoriId { get; set; }
        public virtual Kategori kategori { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly  ")]

        public ICollection<Etiket> etikets { get; set; }




    }
}