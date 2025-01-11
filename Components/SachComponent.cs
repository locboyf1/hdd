using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Components
{
    [ViewComponent(Name = "Sach")]
    public class SachComponent : ViewComponent
    {
        private readonly DataContext _context;

        public SachComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // var listOfPost = (from p in _context.viewPostMenus
            //                     where (p.IsActive == true)
            //                     orderby p.PostID descending
            //                     select p).Take(6).ToList();
            var listOfPost = await _context.viewSaches
                                    .Where( p => p.IsActive == true)
                                    .OrderBy(p => p.Masach)
                                    .ToListAsync();

            return View("Default", listOfPost);
        }
        
    }
}