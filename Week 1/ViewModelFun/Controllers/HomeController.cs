using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers;

public class HomeController : Controller
{
    // deleted everything but this IAction, went into _Layout.cshtml in Shared, deleted header and footer
    [HttpGet("")]
    public IActionResult Index()
    {
        // we pass the message in as a string variable
        string message = "This is a message";
        // we return a view with the name of the file and the message
        return View("Index", message);
    }

    [HttpGet("numbers")]

    public IActionResult Numbers()
    {
        int[] numArray = {1,2,3,45,5,6,8};
        NumberModel numbers = new NumberModel
        {
            Numbers = numArray
        };
        return View(numbers);
    }

    [HttpGet("user")]
    public IActionResult User()
    {
        string firstName = "Floor";
        string lastName = "Garbanzo";
        UserModel user = new UserModel
        {
            FirstName = firstName,
            LastName = lastName
        };
        return View(user);
    }

    [HttpGet("users")]
    public IActionResult Users()
    {
        List<UserModel> userList = new List<UserModel>()
        {
            new UserModel {FirstName = "Steve", LastName = "Slammer"},
            new UserModel {FirstName = "Paulie", LastName = "Germeater"},
            new UserModel {FirstName = "Concrete", LastName = "Parachute"},
            new UserModel {FirstName = "Flag", LastName = "Dag"},
            new UserModel {FirstName = "Patricia", LastName = "Gobsmakker"}
        };
        return View(userList);
    }

}
