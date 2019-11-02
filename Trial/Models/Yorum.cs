using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trial.Models
{
    public class ViewModel
    {

        public IEnumerable<Markalar> markalars { get; set; }
       public IEnumerable<CesitMakyaj> CesitMakyajs { get; set; }
       public IEnumerable<YorumPuan>  yorumPuans { get; set; }
       public IEnumerable<UyeYorum> uyeYorums { get; set; }

    }
}