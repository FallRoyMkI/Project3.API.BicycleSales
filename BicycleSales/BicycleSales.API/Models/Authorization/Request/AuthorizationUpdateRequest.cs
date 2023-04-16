using System.ComponentModel.DataAnnotations;

namespace BicycleSales.API.Models.AuthorizationProduct.Request;
public class AuthorizationUpdateRequest
{
    [Required]
    public int Id { get; set; }

    public string? Login { get; set; }
    public string? Password { get; set; }
}
