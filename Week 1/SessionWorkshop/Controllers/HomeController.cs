using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View();
    }

    [HttpPost("submission")]
    public IActionResult Submission(UserModel form)
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

    [HttpGet("logout")]
    public ViewResult Logout()
    {
        HttpContext.Session.Clear();
        return View("Index");
    }
}
