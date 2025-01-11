using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Company.Areas.Admin.Models;
using Company.Models;
using Company.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Company.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DangnhapController : Controller
    {
        private readonly DataContext _context;
        public DangnhapController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminNV nguoisd)
        {
            if ( nguoisd == null) return NotFound();

            string pw = Functions.MD5Matkhau(nguoisd.Matkhau);

            var check = _context.AdminNVs.Where(u => (u.Email == nguoisd.Email) && (u.Matkhau == pw)).FirstOrDefault();
            if (check == null)
            {
                Functions._Message = "Tên người dùng và mật khẩu không hợp lệ!";
                return RedirectToAction("Index", "Dangnhap");
            }

            Functions._Message = string.Empty;
            Functions._MaNV = check.MaNV;
            Functions._HotenNV = string.IsNullOrEmpty(check.HotenNV) ? string.Empty : check.HotenNV;
            Functions._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;
            return RedirectToAction("Index", "Home");
        }
    }
}