#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace DateValidator.Models;

public class DateModel
{
    [Required]
    public string Name {get;set;}
    [Required]
    [DataType(DataType.DateTime)]
    [Range(typeof(DateTime), "0001-12-31", "2023-08-31",  ErrorMessage = "Date must be in the past")]
    public DateTime Date {get;set;}
}