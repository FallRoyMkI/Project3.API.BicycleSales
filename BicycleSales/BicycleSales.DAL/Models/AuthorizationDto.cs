using System.ComponentModel.DataAnnotations;
using BicycleSales.Constants;

namespace BicycleSales.DAL.Models;

public class AuthorizationDto
{
    [Key]
    public int Id { get; set; }

    public string? Login { get; set; }
    public string? Password { get; set; }
    public UserStatus? Status { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is AuthorizationDto auth &&
               Id == auth.Id &&
               Login == auth.Login &&
               Password == auth.Password &&
               Status == auth.Status;
    }
}