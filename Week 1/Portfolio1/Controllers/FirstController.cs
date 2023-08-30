// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace ViewRendering.Controllers;   
public class FirstController : Controller
{
    [HttpGet]
    [Route("")]
    public string Index()
    {
        return "This is my index";
    }

    [HttpGet]
    [Route("projects")]
    public string Projects()
    {
        return "These are my projects";
    }

    [HttpGet]
    [Route("contact")]
    public string Contact()
    {
        return "This is my Contact!";
    }
}