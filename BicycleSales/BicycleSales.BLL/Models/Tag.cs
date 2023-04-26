namespace BicycleSales.BLL.Models;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is Tag tag &&
               Id == tag.Id &&
               Name == tag.Name;
    }
}