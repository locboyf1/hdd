using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Company.Models;
using Company.Utilities;
namespace Company.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        if (!Functions.DGIsDangnhap()) return Redirect("/dangnhap");
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
