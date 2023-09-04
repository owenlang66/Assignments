using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers;

public class HomeController : Controller
{
    // this is the landing page
    [HttpGet("")]
    public ViewResult Index()
    {
        return View();
    }

    [HttpPost("Login")]
    public IActionResult Login(string Name)
    {
        HttpContext.Session.SetString("User", Name);
        HttpContext.Session.SetInt32("IntVal", 22);
        if (ModelState.IsValid)
        {
            return RedirectToAction("Success");
        }
        else
        {
            return RedirectToAction("Index");
        }
    }

    [HttpPost("Change")]
    public IActionResult Change(string edit)
    {
        int? num = HttpContext.Session.GetInt32("IntVal");
        if (edit == "x2")
        {
            int editNum = (int)(num * 2);
            HttpContext.Session.SetInt32("IntVal", editNum);
        }
        else if (edit == "-1")
        {
            int editNum = (int)(num - 1);
            HttpContext.Session.SetInt32("IntVal", editNum);
        }
        else if (edit == "+1")
        {
            int editNum = (int)(num + 1);
            HttpContext.Session.SetInt32("IntVal", editNum);
        }
        else
        {
            Random rand = new Random();
            int randNum = rand.Next(1, 11);
            int editNum = (int)(num + randNum);
            HttpContext.Session.SetInt32("IntVal", editNum);
        }
        return RedirectToAction("Success");
    }

    [HttpPost("Logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [HttpGet("Success")]
    public IActionResult Success()
    {
        string? User = HttpContext.Session.GetString("User");
        return View();
    }
}