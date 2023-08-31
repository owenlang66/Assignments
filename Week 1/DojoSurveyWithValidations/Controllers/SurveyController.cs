// This brings all the MVC features we need to this file
using System.Reflection.Metadata.Ecma335;
using DojoSurveyWithValidations.Models;
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace DojoSurveyWithValidations.Controllers;   
public class SurveyController : Controller   // Remember inheritance?    
{      
    [HttpGet("")]
    public ViewResult Index()
    {
        return View();
    }

    // this "submit" corresponds to the action tag on the form
    [HttpPost("submit")]
    // 
    public IActionResult Submit(SurveyModel submitForm)
    {
        if(ModelState.IsValid)
        {
            // all of the form data is stored in this submitForm now
            return View("Results", submitForm);
        }
        else
        {
            return View("Index");
        }
    }
}