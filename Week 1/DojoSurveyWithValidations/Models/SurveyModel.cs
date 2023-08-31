#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DojoSurveyWithValidations.Models;

public class SurveyModel
{
    [Required(ErrorMessage = "WHY IS YOUR NAME NOT TWO LETTERS")]
    [MinLength(2)]
    public string Name {get;set;} 
    [Required]
    public string Location {get;set;} 
    [Required]
    public string Language {get;set;} 
    [MinLength(21)]
    // comments are not required, signified by the ? right there
    public string? Comments {get;set;} 
}