using System.ComponentModel.DataAnnotations;

namespace BicycleSales.DAL.Models;

public class FactoryDto
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is FactoryDto factory &&
               Id == factory.Id &&
               Name == factory.Name;
    }
}