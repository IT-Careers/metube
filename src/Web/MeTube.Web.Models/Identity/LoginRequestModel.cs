using System.ComponentModel.DataAnnotations;

namespace MeTube.Web.Models.Identity;

public class LoginRequestModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
