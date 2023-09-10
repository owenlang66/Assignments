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

// NEED CONTEXT HERE IF WANT TO TALK TO THE DB 
    public IActionResult Index()
    {
        return RedirectToAction("AllDishes", "Dish");
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
