using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using ChefsDishes.Models;
using System.Reflection.Metadata.Ecma335;

namespace ChefsDishes.Controllers;

public class ChefController : Controller
{
    private readonly ILogger<ChefController> _logger;

    private MyContext _context;

    public ChefController(ILogger<ChefController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    // **** LANDING PAGE ******************* not anymore sike 
    // [HttpGet("")]
    // public IActionResult Index()
    // {
    //     List<Dish> AllDishes = _context.Dishes.ToList();
    //     return View();
    // }

    // [HttpGet("")]
    // public IActionResult AllChefs()
    // {
    //     return View();
    // }


    // ***** CREATE ***************
    [HttpGet("chefs/new")]
    public IActionResult NewChef()
    {
        return View();
    }

    [HttpPost("chefs/create")]
    public IActionResult CreateChef(Chef newChef)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("AllChefs");
        }
        else
        {
            // if invalid redirect to the form again
            return View("NewChef");
        }
    }

    // ****** GET ALL **************
    // coincidentally this is also our landing page
    [HttpGet("")]
    public IActionResult AllChefs()
    {
        List<Chef> chefs = _context.Chefs.ToList();
        return View(chefs);
    }

    // ******


}