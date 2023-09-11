#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace ProductsCategories.Models;

public class Category 
{
    [Key]
    public int CategoryId {get;set;}

    [Required]
    public string Name {get;set;}

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Association> Association2 {get;set;} = new List<Association>();
}