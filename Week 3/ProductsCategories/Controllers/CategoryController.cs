using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsCategories.Models;

namespace ProductsCategories.Controllers;

public class CategoryController : Controller
{
    private readonly ILogger<CategoryController> _logger;

    private MyContext _context;

    public CategoryController(ILogger<CategoryController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }


    // ********* CREATE NEW ***************
    [HttpGet("/category/new")]
    public ViewResult NewCategory()
    {
        List<Category> categories = _context.Categories.ToList();
        return View(categories);
    }

    [HttpPost("category/create")]
    public IActionResult CreateCategory(Category newCategory)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("NewCategory");
        } else {
            // if invalid redirect to the form again
            return View("NewCategory");
        }
    }
}