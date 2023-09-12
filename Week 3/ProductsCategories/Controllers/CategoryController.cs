using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        // ViewBag.Categories = new SelectList(categories, "CategoryId", "Name");
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

        // ********* GET ONE **************
    [HttpGet("category/{categoryId}")]
    public IActionResult ViewCategory(int categoryId)
    {
        Category? OneCategory = _context.Categories.FirstOrDefault(d => d.CategoryId == categoryId);
        if (OneCategory == null){
            return RedirectToAction("ViewCategory");
        }
        return View(OneCategory);
    }

    [HttpGet("categories")]
    public ViewResult AllCategories()
    {
        // allows us to access the database
        List<Category> AllCategories = _context.Categories.OrderByDescending(d => d.CreatedAt).ToList();
        return View(AllCategories);
    }
}
