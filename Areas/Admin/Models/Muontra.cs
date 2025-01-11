using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Areas.Admin.Models
{
    [Table("tblMuontra")]
    public class Muontra
    {
        [Key]

        public int Mamuontra { get; set; }

        public int MaNV { get; set; }

        public int Masach { get; set; }

        public int Madocgia { get; set; }

        public DateTime Ngaymuon { get; set; }

        public DateTime Ngaytra { get; set; }

        public Decimal Phimuon { get; set; }
        
    }
}