using System.ComponentModel.DataAnnotations;
using BicycleSales.Constants;

namespace BicycleSales.DAL.Models;

public class AuthorizationDto
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Login { get; set; }

    [Required]
    public string? Password { get; set; }

    [Required]
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