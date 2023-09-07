using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDalicious.Models;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CRUDalicious.Controllers;

public class DishController : Controller
{
    private readonly ILogger<DishController> _logger;
    private MyContext _context;

    public DishController(ILogger<DishController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

// ********* CREATE NEW ***************
    [HttpGet("dishes/new")]
    public ViewResult NewDish()
    {
        return View();
    }


    [HttpPost("dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        } else {
            return View("NewDish");
        }
    }

    // *************** GET ALL *************

    [HttpGet("dishes")]
    public ViewResult AllDishes()
    {
        List<Dish> AllDishes = _context.Dishes.OrderByDescending(d => d.CreatedAt).ToList();
        return View(AllDishes);
    }

    // ********* GET ONE ***************

    [HttpGet("dishes/{dishId}")]
    public IActionResult ViewDish(int dishId)
    {
        Dish? OneDish = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
        if (OneDish == null){
            return RedirectToAction("AllDishes");
        }
        return View(OneDish);
    }

    // ************ DELETE ********************

    [HttpPost("dishes/{dishId}/delete")]
    public IActionResult DeleteDish(int dishId)
    {
        Dish? ToBeDeleted = _context.Dishes.SingleOrDefault(d => d.DishId == dishId);
        if (ToBeDeleted != null){
            _context.Remove(ToBeDeleted);
            _context.SaveChanges();
        }
        return RedirectToAction("AllDishes");
    }

    // ******************* EDIT ******************

    [HttpGet("dishes/{dishId}/edit")]
    public IActionResult EditDish(int dishId)
    {
        Dish? ToBeEdited = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
        if (ToBeEdited == null){
            return RedirectToAction("AllDishes");
        }
        return View(ToBeEdited);
    }

    [HttpPost("dishes/{dishId}/update")]
    public IActionResult UpdateDish(int dishId, Dish editedDish)
    {
        Dish? ToBeUpdated = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
        if (!ModelState.IsValid || ToBeUpdated == null)
        {
            return View("EditDish", ToBeUpdated);
        }
        ToBeUpdated.Chef = editedDish.Chef;
        ToBeUpdated.Name = editedDish.Name;
        ToBeUpdated.Calories = editedDish.Calories;
        ToBeUpdated.Tastiness = editedDish.Tastiness;
        ToBeUpdated.Description = editedDish.Description;
        ToBeUpdated.UpdatedAt = DateTime.Now;
        _context.SaveChanges();

        return RedirectToAction("ViewDish", new{dishId = dishId});
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
