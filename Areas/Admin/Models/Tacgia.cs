using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Areas.Admin.Models
{
    [Table("tblTacgia")]
    public class Tacgia
    {
        [Key]

        public int Matacgia { get; set; }

        public string? Tentacgia { get; set; }

        public DateTime Namsinh { get; set; }

        public string?  Quequan { get; set; }
    }
}