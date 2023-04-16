using System.ComponentModel.DataAnnotations;

namespace BicycleSales.API.Models.AuthorizationProduct.Request;
public class AuthorizationAddRequest
{
    [Required]
    public string Login { get; set; }
    [Required]
    public string Password { get; set; }
}
