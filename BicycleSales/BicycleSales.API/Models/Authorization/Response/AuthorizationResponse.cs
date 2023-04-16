using BicycleSales.Constants;

namespace BicycleSales.API.Models.AuthorizationProduct.Response;
public class AuthorizationResponse
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public UserStatus Status { get; set; }
}
