#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace SessionWorkshop.Models;

public class UserModel
{
    [Required]
    public string Name {get;set;}
}