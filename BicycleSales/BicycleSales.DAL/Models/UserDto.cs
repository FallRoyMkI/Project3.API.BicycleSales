using System.ComponentModel.DataAnnotations;

namespace BicycleSales.DAL.Models;

public class UserDto
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public bool? IsMale { get; set; }
    [Required]
    public AuthorizationDto Authorization { get; set; }
    public ShopDto? Shop { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is UserDto user &&
               Id == user.Id &&
               Name == user.Name &&
               Email == user.Email &&
               Phone == user.Phone &&
               IsMale == user.IsMale &&
               Authorization.Equals(user.Authorization) &&
               Shop.Equals(user.Shop);
    }
}
