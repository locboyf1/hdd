using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Company.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Company.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            if (!Functions.IsDangnhap())
                //return RedirectToAction("Index", "Dangnhap");
                return Redirect("/Admin/DangNhap");
            return View();
        }

        public IActionResult Logout()
        {
            Functions._MaNV = 0;
            Functions._HotenNV = string.Empty;
            Functions._Email = string.Empty;
            Functions._Message = string.Empty;
            return RedirectToAction("Index", "Home");
        }

    }
}