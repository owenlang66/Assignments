using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers;

[SessionCheck]
public class WeddingController : Controller
{
    private readonly ILogger<WeddingController> _logger;

    private MyContext _context;

    public WeddingController(ILogger<WeddingController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("weddings")]
    public IActionResult Dashboard()
    {
        List<Wedding> allWeddings = _context.Weddings.Include(w => w.Users).ToList();
        return View(allWeddings);
    }

    [HttpGet("weddings/new")]
    public IActionResult NewWedding()
    {
        return View();
    }

    [HttpPost("weddings/create")]
    public IActionResult CreateWedding(Wedding newWedding)
    {
        if (ModelState.IsValid)
        {
            newWedding.UserId = (int)HttpContext.Session.GetInt32("UserId");
            _context.Add(newWedding);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        else
        {
            // if invalid redirect to the form again
            return View("NewWedding");
        }
    }

    [HttpPost("weddings/{id}/delete")]
    public RedirectToActionResult DeleteWedding(int id)
    {
        Wedding? toDelete = _context.Weddings.SingleOrDefault(w => w.WeddingId == id);
        if (toDelete != null)
        {
            _context.Remove(toDelete);
            _context.SaveChanges();
        }
        return RedirectToAction("Dashboard");
    }

    [HttpPost("weddings/{id}/rsvp")]
    public RedirectToActionResult ToggleRSVP(int id)
    {
        int UserId = (int)HttpContext.Session.GetInt32("UserId");
        Guest isRSVP = _context.Guests.FirstOrDefault(r=>r.WeddingId == id && r.UserId == UserId);
        if (isRSVP == null)
        {
            Guest newRSVP = new()
            {
                UserId = UserId,
                WeddingId = id
            };
            _context.Add(newRSVP);
        } else
        {
            _context.Remove(isRSVP);
        }
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }


    [HttpGet("weddings/{id}")]
    public IActionResult ViewWedding(int id)
    {
        Wedding? oneWedding = _context.Weddings
                                    .Include(w=>w.Creator)
                                    .Include(w=>w.Users)
                                    .ThenInclude(u=>u.User)
                                    .FirstOrDefault(w=>w.WeddingId == id);
        if (oneWedding == null)
        {
            return RedirectToAction("Dashboard");
        }
        return View(oneWedding);

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


