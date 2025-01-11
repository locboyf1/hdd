using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Company.Areas.Admin.Models;
using Company.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Company.Areas.Admin.Controllers
{
   [Area("Admin")]
    public class DocgiaController : Controller
    {

        private readonly DataContext _context;

        public DocgiaController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var mnList = _context.Docgias.OrderBy(m => m.Madocgia).ToList();
            return View(mnList);
        }

        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]

        public IActionResult Create(Docgia dg)
        {
            if (ModelState.IsValid)
            {
                _context.Docgias.Add(dg);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dg);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var mn = _context.Docgias.Find(id);
            if (mn == null)
                return NotFound();
            return View(mn);
        }
        // được thực hiện khi xác nhận xóa
        [HttpPost]

        public IActionResult Delete(int id)
        {
            var delDocgia = _context.Docgias.Find(id);
            if (delDocgia == null)
                return NotFound();
            _context.Docgias.Remove(delDocgia);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            var dg = _context.Docgias.Find(id);
            return View(dg);
        }
        [HttpPost]

        public IActionResult Edit(Docgia dg)
        {
            if (ModelState.IsValid)
            {
                _context.Docgias.Update(dg);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dg);
        }
    
    }
}