// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace CountDown.Controllers;   
public class CountdownController : Controller   // Remember inheritance?    
{      
  
    
    [HttpGet("")]
    public ViewResult Index()
    {
        DateTime endDate = new DateTime(2025, 5, 6, 12, 22, 10);
        ViewBag.EndDate = endDate;
        return View();
    }

}