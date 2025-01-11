using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Components
{
    [ViewComponent(Name = "MenuView")]

    public class MenuViewComponent : ViewComponent
    {

        private readonly DataContext _context;

        public MenuViewComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listMenu = await _context.Menus.Where(p => p.IsActive == true).OrderByDescending(p => p.Position ).ToListAsync();
            return View("Default", listMenu);
        }
        
    }
}
