using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Areas.Admin.Models
{
    [Table("tblNhaXB")]
    public class NhaXB
    {
        [Key]

        public int MaNXB { get; set; }

        public string? TenNXB { get; set; }

        public string?  Diachi { get; set; }

        public string?  Email { get; set; }

        public string? SDT  { get; set; }

    }
}