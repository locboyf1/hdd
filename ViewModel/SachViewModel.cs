using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Areas.Admin.Models;

namespace Company.ViewModel
{
    public class SachViewModel
    {
        public Sach? Sach { get; set; }
        public NhaXB? NhaXB { get; set; }
        public Theloai? Theloai { get; set; }
        public Tacgia? Tacgia { get; set; }
    }
}