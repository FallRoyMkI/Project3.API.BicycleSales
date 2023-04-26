namespace BicycleSales.BLL.Models;

public class Factory
{
    public int Id { get; set; }

    public string Name { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is Factory factory &&
               Id == factory.Id &&
               Name == factory.Name;
    }
}