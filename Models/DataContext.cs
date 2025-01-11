using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Company.Areas.Admin.Models;

namespace Company.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}
        public DbSet<tblMenu> Menus { get; set; }
        
        public DbSet<viewSach> viewSaches { get; set; }
        
        public DbSet<AdminMenu> AdminMenus { get; set; }

        public DbSet<Tacgia> Tacgias { get; set; }

        public DbSet<Sach> Sachs { get; set; }

        public DbSet<Theloai> Theloais { get; set; }

        public DbSet<NhaXB> NhaXBs { get; set; }

        public DbSet<AdminNV> AdminNVs { get; set; }

        public DbSet<Docgia> Docgias { get; set; }

        public DbSet<Muontra> Muontras { get; set; }
        public DbSet<BookView> BookViews { get; set; }

    }
}