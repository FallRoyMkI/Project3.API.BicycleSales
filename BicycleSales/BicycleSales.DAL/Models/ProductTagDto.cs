using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BicycleSales.DAL.Models;

public class ProductTagDto
{
    [Key]
    public int Id { get; set; }

    public int ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public virtual ProductDto Product { get; set; }

    public int TagId { get; set; }
    [ForeignKey(nameof(TagId))]
    public virtual TagDto Tag { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is ProductTagDto productTag &&
               Id == productTag.Id &&
               ProductId == productTag.ProductId &&
               Product.Equals(productTag.Product) &&
               TagId == productTag.TagId &&
               Tag.Equals(productTag.Tag);
    }
}