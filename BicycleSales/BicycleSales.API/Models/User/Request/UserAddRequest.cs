using System.ComponentModel.DataAnnotations;

namespace BicycleSales.API.Models.User.Request;

public class UserAddRequest
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public bool IsMale { get; set; }
    [Required]
    public int AuthorizationId { get; set; }
    [Required]
    public int ShopId { get; set; }
}
