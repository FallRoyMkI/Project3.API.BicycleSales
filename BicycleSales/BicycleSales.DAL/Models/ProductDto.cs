using System.ComponentModel.DataAnnotations;

namespace BicycleSales.DAL.Models;

public class ProductDto
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
    public int Cost { get; set; }
    public bool IsDeleted { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is ProductDto product &&
               Id == product.Id &&
               Name == product.Name &&
               Cost == product.Cost &&
               IsDeleted == product.IsDeleted;
    }
}