using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Company.Areas.Admin.Dto;
using Company.Areas.Admin.Models;
using Company.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Company.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Sachcontroller : Controller
    {
        private readonly DataContext _context;

        public Sachcontroller(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var mnList = _context.Sachs.OrderBy(m => m.Masach).ToList();
            return View(mnList);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Matheloai = new SelectList(await _context.Theloais.ToListAsync(), "Matheloai", "Tentheloai");
            ViewBag.MaNXB = new SelectList(await _context.NhaXBs.ToListAsync(), "MaNXB", "TenNXB");
            ViewBag.Matacgia = new SelectList(await _context.Tacgias.ToListAsync(), "Matacgia", "Tentacgia");
            return View();
        }
        [HttpPost]

        public IActionResult Create(Sach s)
        {
            if (ModelState.IsValid)
            {
                _context.Sachs.Add(s);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(s);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var s = _context.Sachs.Find(id);
            if (s == null)
                return NotFound();
            return View(s);
        }
        // được thực hiện khi xác nhận xóa
        [HttpPost]

        public IActionResult Delete(int id)
        {
            var delSach = _context.Sachs.Find(id);
            if (delSach == null)
                return NotFound();
            _context.Sachs.Remove(delSach);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var s = await _context.Sachs.FirstOrDefaultAsync(p => p.Masach == id);
            ViewBag.Matheloai = new SelectList(_context.Theloais, "Matheloai", "Tentheloai");
            ViewBag.MaNXB = new SelectList(_context.NhaXBs, "MaNXB", "TenNXB");
            ViewBag.Matacgia = new SelectList(_context.Tacgias, "Matacgia", "Tentacgia");
            return View(s);
        }
        [HttpPost]

        public IActionResult Edit(Sach s)
        {
            if (ModelState.IsValid)
            {
                _context.Sachs.Update(s);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(s);
        }
    }
}