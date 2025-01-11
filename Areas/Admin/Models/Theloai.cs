using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Areas.Admin.Models
{
    [Table("tblTheloai")]
    public class Theloai
    {
        [Key]

        public int Matheloai { get; set; }

        public string? Tentheloai { get; set; }

        public string?  Mota { get; set; }
    }
}