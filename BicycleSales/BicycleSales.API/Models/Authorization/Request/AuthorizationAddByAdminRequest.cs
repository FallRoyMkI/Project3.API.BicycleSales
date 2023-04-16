using System.ComponentModel.DataAnnotations;
using BicycleSales.Constants;

namespace BicycleSales.API.Models.AuthorizationProduct.Request;

public class AuthorizationAddByAdminRequest
{
    [Required]
    public string Login { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public UserStatus Status { get; set; }
}