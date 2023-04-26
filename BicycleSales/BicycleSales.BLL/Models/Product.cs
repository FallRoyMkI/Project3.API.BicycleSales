namespace BicycleSales.BLL.Models;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; }
    public int Cost { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is Product product &&
               Id == product.Id &&
               Name == product.Name &&
               Cost == product.Cost;
    }
}