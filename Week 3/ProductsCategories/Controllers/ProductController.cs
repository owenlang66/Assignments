using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsCategories.Models;

namespace ProductsCategories.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;

    private MyContext _context;

    public ProductController(ILogger<ProductController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    // public IActionResult Index()
    // {
    //     return View("NewProduct");
    // }

    // ********* CREATE NEW ***************
    [HttpGet("")]
    public ViewResult NewProduct()
    {
        List<Product> products = _context.Products.ToList();
        return View(products);
    }

    [HttpPost("products/create")]
    public IActionResult CreateProduct(Product newProduct)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("NewProduct");
        } else {
            // if invalid redirect to the form again
            return View("NewProduct");
        }
    }

    // ********* GET ONE **************
    [HttpGet("products/{productId}")]
    public IActionResult ViewProduct(int productId)
    {
        // LINQ query that grabs that one productId 
        Product? OneProduct = _context.Products.FirstOrDefault(d => d.ProductId == productId);
        if (OneProduct == null){
            return RedirectToAction("AllProducts");
        }
        return View(OneProduct);
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
