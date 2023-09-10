#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace CRUDalicious.Models;

public class Dish 
{ 
    [Key]
    public int DishId {get;set;}

    [Required]
    public string Chef {get;set;}

    [Required]
    public string Name {get;set;}

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Must have calories")]
    public int Calories {get;set;}

    [Required]
    [Range(1, 5)]
    public int Tastiness {get;set;}

    [Required]
    public string Description {get;set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}