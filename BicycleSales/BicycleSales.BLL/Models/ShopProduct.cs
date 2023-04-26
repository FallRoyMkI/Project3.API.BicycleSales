namespace BicycleSales.BLL.Models;

public class ShopProduct
{
    public int Id { get; set; }

    public int ProductCount { get; set; }

    public int ShopId { get; set; }
    public Shop Shop { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is ShopProduct shopProduct &&
               Id == shopProduct.Id &&
               ProductCount == shopProduct.ProductCount &&
               ShopId == shopProduct.ShopId &&
               Shop.Equals(shopProduct.Shop) &&
               ProductId == shopProduct.ProductId &&
               Product.Equals(shopProduct.Product);
    }
}