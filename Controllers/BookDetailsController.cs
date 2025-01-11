using Company.Models;
using Company.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace Company.Components
{

    public class BookDetailsController : Controller
    {
        private readonly DataContext _context;

        public BookDetailsController(DataContext context)
        {
            _context = context;
        }

        [Route("post-{slug}-{id:long}.html")]
        public async Task<IActionResult> Index(string slug, long id) {
            System.Console.WriteLine(slug);
            System.Console.WriteLine(id);
            // var model = await _context.Sachs.FirstOrDefaultAsync(p => p.Masach == id);
            var model = await (from sach in _context.Sachs
                            join nxb in _context.NhaXBs on sach.MaNXB equals nxb.MaNXB
                            join theloai in _context.Theloais on sach.Matheloai equals theloai.Matheloai
                            join tacgia in _context.Tacgias on sach.Matacgia equals tacgia.Matacgia
                            select new SachViewModel {
                             Sach =  sach,NhaXB = nxb,Theloai = theloai, Tacgia =tacgia
                            }
                            ).FirstOrDefaultAsync(p => p.Sach.Masach == id);
            if(model == null) return NotFound(); 
            return View(model);
        }
        // [HttpGet]
        // [Route("/post-{slug}-{id}.html")]
        // public async Task<IActionResult> Index(long? id)
        // {
        //     return View();
        //     // if (id == null) return NotFound();
        //     // var post = await _context.viewPostMenus
        //             // .FirstOrDefaultAsync(m => (m.PostID == id) && (m.IsActive == true));
        //     // if (post == null) return NotFound();
        //     // return View("Index",post);
        // }

       

        
    }
}