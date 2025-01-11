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
    public class TacgiaController : Controller
    {

        private readonly DataContext _context;

        public TacgiaController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var mnList = _context.Tacgias.OrderBy(m => m.Matacgia).ToList();
            return View(mnList);
        }

        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]

        public IActionResult Create(Tacgia tg)
        {
            if (ModelState.IsValid)
            {
                _context.Tacgias.Add(tg);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tg);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var mn = _context.Tacgias.Find(id);
            if (mn == null)
                return NotFound();
            return View(mn);
        }
        // được thực hiện khi xác nhận xóa
        [HttpPost]

        public IActionResult Delete(int id)
        {
            var delTacgia = _context.Tacgias.Find(id);
            if (delTacgia == null)
                return NotFound();
            _context.Tacgias.Remove(delTacgia);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            var tg = _context.Tacgias.Find(id);
            return View(tg);
        }
        [HttpPost]

        public IActionResult Edit(Tacgia tg)
        {
            if (ModelState.IsValid)
            {
                _context.Tacgias.Update(tg);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tg);
        }
    
    }
}