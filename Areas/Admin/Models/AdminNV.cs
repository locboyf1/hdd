using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Areas.Admin.Models
{
    [Table("tblNhanvien")]
    public class AdminNV
    {
        [Key]

        public int MaNV { get; set; }

        public string? HotenNV { get; set; }

        public string? Email { get; set; }

        public string? Matkhau { get; set; }

        public bool? IsActive { get; set; }
    }
}