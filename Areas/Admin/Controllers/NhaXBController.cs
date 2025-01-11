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
    public class NhaXBController : Controller
    {

        private readonly DataContext _context;

        public NhaXBController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var mnList = _context.NhaXBs.OrderBy(m => m.MaNXB).ToList();
            return View(mnList);
        }

        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]

        public IActionResult Create(NhaXB nxb)
        {
            if (ModelState.IsValid)
            {
                _context.NhaXBs.Add(nxb);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nxb);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var mn = _context.NhaXBs.Find(id);
            if (mn == null)
                return NotFound();
            return View(mn);
        }
        // được thực hiện khi xác nhận xóa
        [HttpPost]

        public IActionResult Delete(int id)
        {
            var delNhaXB = _context.NhaXBs.Find(id);
            if (delNhaXB == null)
                return NotFound();
            _context.NhaXBs.Remove(delNhaXB);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            var nxb = _context.NhaXBs.Find(id);
            return View(nxb);
        }
        [HttpPost]

        public IActionResult Edit(NhaXB nxb)
        {
            if (ModelState.IsValid)
            {
                _context.NhaXBs.Update(nxb);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nxb);
        }
    
    }
}