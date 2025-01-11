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

namespace Company.Controllers
{
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
        public ActionResult Index(Docgia nguoisd)
        {
            if (nguoisd == null) return NotFound();

            var check = _context.Docgias.Where(u => (u.Email == nguoisd.Email)).FirstOrDefault();
            if (check != null)
            {
                Functions._Message = "Email tồn tại";
                return RedirectToAction("Index", "Dangky");
            }

            Functions._Message = string.Empty;
            nguoisd.Matkhau = Functions.MD5Matkhau(nguoisd.Matkhau);
            _context.Docgias.Add(nguoisd);
            _context.SaveChanges();
            return RedirectToAction("Index", "Dangnhap");
        }
    }
}