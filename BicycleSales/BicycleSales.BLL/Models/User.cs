using BicycleSales.DAL.Models;

namespace BicycleSales.BLL.Models;

public class User
{
    public int Id { get; set; }

    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public bool? IsMale { get; set; }

    public int AuthorizationId { get; set; }
    public Authorization Authorization { get; set; }

    public int ShopId { get; set; }
    public Shop Shop { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is UserDto user &&
               Id == user.Id &&
               Name == user.Name &&
               Email == user.Email &&
               Phone == user.Phone &&
               IsMale == user.IsMale &&
               AuthorizationId == user.AuthorizationId &&
               Authorization.Equals(user.Authorization) &&
               ShopId == user.ShopId &&
               Shop.Equals(user.Shop);
    }
}