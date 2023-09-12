#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace WeddingPlanner.Models;

public class Wedding 
{ 
    [Key]
    public int WeddingId {get;set;}

    [Required]
    public string WedderOne {get;set;}

    [Required]
    public string WedderTwo {get;set;}

    [Required(ErrorMessage = "Date is required")]
    [DataType(DataType.Date)]
    [DateValidation(ErrorMessage = "Date must be in the future")]
    public DateTime Date {get;set;}

    [Required]
    public string Address {get;set;}

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    // this tracks which user made which wedding
    // part of our 1-many relationship
    public int UserId {get;set;}
    public User? Creator {get;set;}

    // this is our many-many relationship
    public List<Guest> Users {get;set;} = new List<Guest>();
}

public class DateValidation : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is DateTime Date)
        {
            return Date > DateTime.Today;
        }
        return false;
    }
}
