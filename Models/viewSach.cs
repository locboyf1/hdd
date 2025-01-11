using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Models
{
    [Table("viewSach")]
    public class viewSach
    {
        [Key]

        public int Masach { get; set; }

        public string? Tensach { get; set; }
        
        public int Matacgia { get; set; }
        
        public int Matheloai { get; set; }
        
        public int MaNXB { get; set; }
        
        public DateTime? Namxuatban { get; set; }
        
        public int Soluong { get; set; }
        
        public Decimal Giamuon { get; set; }
        
        public string? Tinhtrang { get; set; }
        
        public string? Tomtat { get; set; }
        
        public string? Anh { get; set; }

        public string? Tentacgia { get; set; }

        public string? Tentheloai { get; set; }

        public string? TenNXB { get; set; }

        public bool? IsActive { get; set; }
        
         }
}