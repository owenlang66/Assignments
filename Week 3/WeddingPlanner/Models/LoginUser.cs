#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models;


public class LoginUser
{
    [Required]    
    [EmailAddress(ErrorMessage = "Invalid Email/Password")]
    // display denotes that if we display it via the label property then it will show up as Email not LogEmail
    [Display(Name ="Email")]
    public string LogEmail { get; set; }    
    
    [Required]    
    [DataType(DataType.Password)]
    [Display(Name ="Password")]
    public string LogPassword { get; set; } 
}