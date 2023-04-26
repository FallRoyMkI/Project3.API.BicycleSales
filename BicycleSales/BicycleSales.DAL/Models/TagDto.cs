using System.ComponentModel.DataAnnotations;

namespace BicycleSales.DAL.Models;

public class TagDto
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is TagDto tag &&
               Id == tag.Id &&
               Name == tag.Name;
    }
}