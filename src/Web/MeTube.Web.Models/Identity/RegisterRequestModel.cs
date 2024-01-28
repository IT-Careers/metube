using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MeTube.Web.Models.Identity;

public class RegisterRequestModel
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }

    [Required]
    [Display(Name = "Username")]
    public string Username { get; set; }

    [Display(Name = "About")]
    public string About { get; set; }

    [Display(Name = "Profile Picture")]
    public IFormFile? ProfilePicture { get; set; }

    [Display(Name = "Cover Picture")]
    public IFormFile? CoverPicture { get; set; }
}
