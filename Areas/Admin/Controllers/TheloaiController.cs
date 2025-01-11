using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Areas.Admin.Models;
using Company.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Company.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TheloaiController : Controller
    {

        private readonly DataContext _context;

        public TheloaiController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var mnList = _context.Theloais.OrderBy(m => m.Matheloai).ToList();
            return View(mnList);
        }

        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]

        public IActionResult Create(Theloai tl)
        {
            if (ModelState.IsValid)
            {
                _context.Theloais.Add(tl);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tl);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var mn = _context.Theloais.Find(id);
            if (mn == null)
                return NotFound();
            return View(mn);
        }
        // được thực hiện khi xác nhận xóa
        [HttpPost]

        public IActionResult Delete(int id)
        {
            var delTheloai = _context.Theloais.Find(id);
            if (delTheloai == null)
                return NotFound();
            _context.Theloais.Remove(delTheloai);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            var tl = _context.Theloais.Find(id);
            return View(tl);
        }
        [HttpPost]

        public IActionResult Edit(Theloai tl)
        {
            if (ModelState.IsValid)
            {
                _context.Theloais.Update(tl);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tl);
        }
    
    }
}