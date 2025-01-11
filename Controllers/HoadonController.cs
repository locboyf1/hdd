using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Models;
using Microsoft.AspNetCore.Mvc;
using Company.Utilities;
using Company.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Company.Controllers
{
    [Route("[controller]")]
    public class HoadonController :Controller
    {
        private static int _masach = 0;
        private readonly DataContext _context;

        public HoadonController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            var checkgia = _context.Sachs.FirstOrDefault(i => i.Masach == id);
            if (checkgia == null)
            {
                return NotFound();
            }

            _masach = id;
            ViewData["Gia"] = checkgia.Giamuon;

            return View();
        }

        [HttpPost]
        public IActionResult Index([Bind] Muontra muontra )
        {
            var checkgia = _context.Sachs.FirstOrDefault(i=>i.Masach == _masach);
            muontra.Masach = _masach;
            muontra.Ngaymuon = DateTime.Now;
            muontra.Madocgia = Functions._MaDG;
            muontra.Phimuon = checkgia.Giamuon;
            _context.Add(muontra);
            _context.SaveChanges();

            return View(muontra);
        }

    }
}