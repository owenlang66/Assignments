// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace ViewRendering.Controllers;   
public class HelloController : Controller   // Remember inheritance?    
{      
  

    [HttpGet("")]
    public ViewResult Index()
    {
        return View();
    }

}