using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DateValidator.Models;

namespace DateValidator.Controllers;

public class HomeController : Controller
{
    // this httpget is just the landing page
    [HttpGet("")]
    public ViewResult Index()
    {
        return View();
    }

    [HttpPost("submission")]
    public IActionResult Submission(DateModel form)
    {
        if(ModelState.IsValid)
        {
            return View("Success", form);
        }
        else
        {
            return View("Index");
        }
    }
}
