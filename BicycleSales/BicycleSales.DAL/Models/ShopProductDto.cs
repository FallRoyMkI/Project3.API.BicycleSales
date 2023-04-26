using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BicycleSales.DAL.Models;

public class ShopProductDto
{
    [Key]
    public int Id { get; set; }

    public int ProductCount { get; set; }

    public int ShopId { get; set; }
    [ForeignKey(nameof(ShopId))]
    public virtual ShopDto Shop { get; set; }

    public int ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public virtual ProductDto Product { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is ShopProductDto shopProduct &&
               Id == shopProduct.Id &&
               ProductCount == shopProduct.ProductCount &&
               ShopId == shopProduct.ShopId &&
               Shop.Equals(shopProduct.Shop) &&
               ProductId == shopProduct.ProductId &&
               Product.Equals(shopProduct.Product);
    }
}