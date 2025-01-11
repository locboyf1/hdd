using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Areas.Admin.Models
{
    [Table("tblDocgia")]
    public class Docgia
    {
        [Key]

        public int Madocgia { get; set; }

        public string? Hoten { get; set; }

        public DateTime Ngaysinh { get; set; }

        public string? Gioitinh { get; set; }

        public int SDT { get; set; }

        public string? Email { get; set; }

        public string? Diachi { get; set; }

        public string? Matkhau { get; set; }
        
    }
}