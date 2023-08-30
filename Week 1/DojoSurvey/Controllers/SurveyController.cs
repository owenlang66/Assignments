// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace DojoSurvey.Controllers;   
public class SurveyController : Controller   // Remember inheritance?    
{      
    [HttpGet("")]
    public ViewResult Index()
    {
        return View();
    }

    // this "submit" corresponds to the action tag on the form
    [HttpPost("submit")]
    public IActionResult Index(string name, string location, string language, string comments)
    {
        // Viewbag is used to pass info from controllers to views
        // so "name" is what we are getting from our form, and then "Name" is what we are calling this when we print it on our results page
        ViewBag.Name = name;
        ViewBag.Language = language;
        ViewBag.Location = location;
        ViewBag.Comments = comments;
        return View("Results");
    }

}