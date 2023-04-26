namespace BicycleSales.BLL.Models;

public class ProductTag
{
    public int Id { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int TagId { get; set; }
    public Tag Tag { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is ProductTag productTag &&
               Id == productTag.Id &&
               ProductId == productTag.ProductId &&
               Product.Equals(productTag.Product) &&
               TagId == productTag.TagId &&
               Tag.Equals(productTag.Tag);
    }
}