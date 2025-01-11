using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Models;
using Microsoft.AspNetCore.Mvc;
using Company.Areas.Admin.Models;

namespace Company.Controllers
{
    public class SachController(DataContext context) : Controller
    {
        private readonly DataContext _context = context;
        public IActionResult Index()
        {
            var bookList = _context.BookViews.Where(m => m.IsActive == true).ToList();
            return View(bookList);
        }

        public IActionResult view(int id)
        {
            var book = _context.BookViews.Where(m => m.Masach == id).FirstOrDefault();
            return View(book);
        }

        [HttpPost]
        public IActionResult hoadon(int id)
        {
            return RedirectToAction("Index", "Hoadon", id);
        }

    }
}