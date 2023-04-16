using System.ComponentModel.DataAnnotations;
using BicycleSales.Constants;

namespace BicycleSales.API.Models.AuthorizationProduct.Request;
public class AuthorizationUpdateByAdminRequest
{
    [Required]
    public int Id { get; set; }

    public UserStatus? Status { get; set; }
}
