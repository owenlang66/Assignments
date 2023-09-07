using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDalicious.Models;

namespace CRUDalicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // [HttpGet("")]
    // public IActionResult Index()
    // {
    //     List<Dish> AllDishes = _context.Dishes.ToList();
    //     return View(AllDishes);
    // }

    public ViewResult Index()
    {
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
