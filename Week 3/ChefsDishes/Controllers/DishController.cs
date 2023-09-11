using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using ChefsDishes.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChefsDishes.Controllers;

public class DishController : Controller
{
    private readonly ILogger<DishController> _logger;

    private MyContext _context;

    public DishController(ILogger<DishController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    // ****** NEW DISHES **************

    [HttpGet("dishes/new")]
    public IActionResult NewDish()
    {
        List<Chef> chefs = _context.Chefs.ToList();
        ViewBag.ChefsList = new SelectList(chefs, "ChefId", "FirstName");
        return View();
    }

    [HttpPost("dishes/create")]
    public IActionResult CreateDish (Dish newDish)
    {
        if(ModelState.IsValid)
        {
            int chosenChefId = newDish.ChefId;
            // grabs the ChefId from the dish
            newDish.Creator = _context.Chefs.FirstOrDefault(c => c.ChefId == chosenChefId);
            // grabs the entirety of the Chef object and assigns it to the Creator, as defined in the model
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("AllDishes");
        } else {
            // if invalid redirect to the form again
            return View("NewDish");
        }
    }

    // ******** ALL DISHES ************
    [HttpGet("dishes/all")]
    public IActionResult AllDishes()
    {
        List<Dish> dishes = _context.Dishes.ToList();
        // grabs the list of all the dishes and created a variable to send through to the alldishes page
        ViewBag.Context = _context;
        // this makes absolutely no sense why I had to use ViewBag to send context through to make the ChefId thing work
        return View(dishes);
    }
}