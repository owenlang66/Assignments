using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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


    // ********** LANDING PAGE *************
    [HttpGet("weddings")]
    public IActionResult Dashboard()
    {
        // brings in all of the weddings to loop through on the dash
        List<Wedding> allWeddings = _context.Weddings.Include(w => w.Users).ToList();
        // returns the View and sends the object with it
        return View(allWeddings);
    }


    // ***** NEW WEDDING *****************
    // just creating the route for the new wedding page
    [HttpGet("weddings/new")]
    public IActionResult NewWedding()
    {
        return View();
    }


    // action that creates the new wedding
    [HttpPost("weddings/create")]
    // pass in the Wedding model and create a new one called newWedding
    public IActionResult CreateWedding(Wedding newWedding)
    {
        if (ModelState.IsValid)
        {
            // first we store the UserId as an attribute of the newly created wedding
            newWedding.UserId = (int)HttpContext.Session.GetInt32("UserId");
            // now we add it to our list using context
            _context.Add(newWedding);
            _context.SaveChanges();
            // redirects us to the view page
            return ViewWedding(newWedding.WeddingId);
        }
        else
        {
            // if invalid redirect to the form again
            return View("NewWedding");
        }
    }

    // ********** DELETE ***************
    [HttpPost("weddings/{id}/delete")]
    // need to rememeber to pass in the id 
    public RedirectToActionResult DeleteWedding(int id)
    {
        // single out the WeddingId that matches our deleteId 
        Wedding? toDelete = _context.Weddings.SingleOrDefault(w => w.WeddingId == id);
        if (toDelete != null)
        {
            _context.Remove(toDelete);
            _context.SaveChanges();
        }
        return RedirectToAction("Dashboard");
    }

    // ******* RSVP *****************
    [HttpPost("weddings/{id}/rsvp")]
    public RedirectToActionResult ToggleRSVP(int id)
    {
        // grab the UserId from session
        int UserId = (int)HttpContext.Session.GetInt32("UserId");
        // using our joining table, checks if there is a record that matches our WeddingId and UserId, which happens if we have already RSVPed
        Guest isRSVP = _context.Guests
                .FirstOrDefault(r=>r.WeddingId == id && r.UserId == UserId);
        if (isRSVP == null)
        {
            // creates that record if it doesn't exist
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

    // ****** GET ONE *******************
    [HttpGet("weddings/{id}")]
    public IActionResult ViewWedding(int id)
    {
        // we are grabbing one of our weddings plus all of the UserIds associated with the rsvp of that wedding
        Wedding? oneWedding = _context.Weddings
                                    .Include(w=>w.Creator)
                                    .Include(w=>w.Users)
                                    .ThenInclude(u=>u.User)
                                    .FirstOrDefault(w=>w.WeddingId == id);
        if (oneWedding == null)
        {
            return RedirectToAction("Dashboard");
        }
        // need to pass in ViewWedding again to redirect to the view after creation
        return View("ViewWedding", oneWedding);

    }

    // ********** EDIT *********************
    [HttpGet("weddings/{id}/edit")]
    public IActionResult EditWedding(int id)
    {
        Wedding? ToBeEdited = _context.Weddings.FirstOrDefault(w => w.WeddingId == id);
        if (ToBeEdited == null)
        {
            return RedirectToAction("Dashboard");
        }
        return View(ToBeEdited);
    }


    [HttpPost("weddings/{id}/update")]
    public IActionResult UpdateWedding(int id, Wedding editedWedding)
    {
        Wedding? ToBeUpdated = _context.Weddings.FirstOrDefault(w => w.WeddingId == id);
        if (!ModelState.IsValid || ToBeUpdated == null)
        {
            return View("EditWedding", ToBeUpdated);
        }
        ToBeUpdated.WedderOne = editedWedding.WedderOne;
        ToBeUpdated.WedderTwo = editedWedding.WedderTwo;
        ToBeUpdated.Address = editedWedding.Address;
        ToBeUpdated.Date = editedWedding.Date;
        ToBeUpdated.UpdatedAt = DateTime.Now;
        _context.SaveChanges();

        return RedirectToAction("ViewWedding", new{id = id});
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

// ZqSTmA9f