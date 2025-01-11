using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Company.Areas.Admin.Components;
using Company.Areas.Admin.Models;
using Company.Models;
using Company.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Company.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DangkyController : Controller
    {
        private readonly DataContext _context;
        public DangkyController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(AdminNV nguoisd)
        {
            if ( nguoisd == null) return NotFound();

            var check = _context.AdminNVs.Where(u => (u.HotenNV == nguoisd.HotenNV)).FirstOrDefault();
            if (check != null)
            {
                Functions._Message = "Tên người dùng tồn tại";
                return RedirectToAction("Index", "Dangky");
            }

            Functions._Message = string.Empty;
            nguoisd.Matkhau = Functions.MD5Matkhau(nguoisd.Matkhau);
            _context.AdminNVs.Add(nguoisd);
            _context.SaveChanges();
            return RedirectToAction("Index", "Dangnhap");
        }
    }
}