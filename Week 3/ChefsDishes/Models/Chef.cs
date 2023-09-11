#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
// using Microsoft.EntityFrameworkCore;
namespace ChefsDishes.Models;

public class Chef 
{
    [Key]
    public int ChefId {get;set;}

    [Required]
    [MinLength(2)]
    public string FirstName {get;set;}

    [Required]
    [MinLength(2)]
    public string LastName {get;set;}

    [Required(ErrorMessage = "Date of Birth is required")]
    [DataType(DataType.Date)]
    [DateValidation(ErrorMessage = "Date of Birth must be in the past")]
    public DateTime DOB {get;set;}

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Dish> AllDishes {get;set;} = new List<Dish>();
}

public class DateValidation : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is DateTime DOB)
        {
            return DOB < DateTime.Today;
        }
        return false;
    }
}

