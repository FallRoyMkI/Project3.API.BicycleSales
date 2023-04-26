using System.ComponentModel.DataAnnotations;

namespace BicycleSales.DAL.Models;

public class ShopDto
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
    public string Location { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is ShopDto shop &&
               Id == shop.Id &&
               Name == shop.Name &&
               Location == shop.Location;
    }
}