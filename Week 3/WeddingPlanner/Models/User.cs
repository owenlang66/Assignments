#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;


namespace WeddingPlanner.Models;

public class User 
{
    [Key]
    public int UserId {get;set;}

    [Required]
    [MinLength(2)]
    public string FirstName  {get;set;}

    [Required]
    [MinLength(2)]
    public string LastName  {get;set;}

    [Required]
    [EmailAddress]
    [UniqueEmail]
    public string Email  {get;set;}

    [Required]
    [MinLength(8)]
    public string Password  {get;set;}
    
    [NotMapped]
    [Compare("Password")]
    public string ConfirmPassword  {get;set;}

    public DateTime CreatedAt  {get;set;} = DateTime.Now;
    public DateTime UpdatedAt  {get;set;} = DateTime.Now;

    // this is part of our many-many, connecting to the joining table
    public List<Guest> Weddings {get;set;} = new List<Guest>();
    // this represents our 1-many relationship from users to weddings
    public List<Wedding> AllWeddings {get;set;} = new List<Wedding>();
}

public class UniqueEmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(value == null)
        {
            return new ValidationResult("Email is required!");
        }
    
        MyContext _context = (MyContext)validationContext.GetService(typeof(MyContext));
    	if(_context.Users.Any(e => e.Email == value.ToString()))
        {
            return new ValidationResult("Email must be unique!");
        } else {
            return ValidationResult.Success;
        }
    }
}

