using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Company.Areas.Admin.Models;
using Company.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Company.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MuontraController : Controller
    {

        private readonly DataContext _context;

        public MuontraController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var mnList = _context.Muontras.OrderBy(m => m.Mamuontra).ToList();
            return View(mnList);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.ListSach = new SelectList(await _context.Sachs.ToListAsync(), "Masach", "Tensach");
            ViewBag.Madocgia = new SelectList(await _context.Docgias.ToListAsync(), "Madocgia", "Hoten");
            return View();
        }
        [HttpPost]

        public IActionResult Create(Muontra mt)
        {
            if (ModelState.IsValid)
            {
                _context.Muontras.Add(mt);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mt);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var mn = _context.Muontras.Find(id);
            if (mn == null)
                return NotFound();
            return View(mn);
        }
        // được thực hiện khi xác nhận xóa
        [HttpPost]

        public IActionResult Delete(int id)
        {
            var delMuontra = _context.Muontras.Find(id);
            if (delMuontra == null)
                return NotFound();
            _context.Muontras.Remove(delMuontra);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            var mt = _context.Muontras.Find(id);
            return View(mt);
        }
        [HttpPost]

        public IActionResult Edit(Muontra mt)
        {
            if (ModelState.IsValid)
            {
                _context.Muontras.Update(mt);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mt);
        }
    
    }
}