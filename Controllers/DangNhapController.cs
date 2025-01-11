using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Company.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Company.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Company.Controllers
{
    public class DangNhapController : Controller
    {
        private readonly ILogger<DangNhapController> _logger;
        private readonly DataContext _context;

        public DangNhapController(ILogger<DangNhapController> logger, DataContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string email, string password){
            
            var pass = Functions.MD5Matkhau(password);
            var kiemtra = _context.Docgias.FirstOrDefault(i=>(i.Email == email)&&(i.Matkhau == pass));
            if(kiemtra == null){
                Functions._Message = "Sai TK MK";
                return View();
            }
            Functions._DGEmail = kiemtra.Email;
            Functions._DGHoTen = kiemtra.Hoten;
            Functions._MaDG = kiemtra.Madocgia;
            Functions._Message = string.Empty;
            return Redirect("/Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}