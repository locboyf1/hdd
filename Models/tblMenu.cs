using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Models
{
    [Table("tblMenu")]

    public class tblMenu
    {
        [Key]

        public int MenuID { get; set; }

        public string? MenuName { get; set; }

        public bool? IsActive { get; set; }

        public string? ControllerName { get; set; }

        public int Levels { get; set; }

        public int ParentID { get; set; }

        public string? Link { get; set; }

        public int MenuOrder { get; set; }
         
        public int Position { get; set; }
    }
}