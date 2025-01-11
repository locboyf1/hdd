using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Areas.Admin.Mtra
{
    public class ViewMuontra
    {
         public IEnumerable<SelectListItemMtra>? Sach { get; set; }
        public IEnumerable<SelectListItemMtra>? Docgia { get; set; }
        
    }

     public class SelectListItemMtra
    {
        public string? Name { get; set; }
        public int? Id { get; set; }
    }
}