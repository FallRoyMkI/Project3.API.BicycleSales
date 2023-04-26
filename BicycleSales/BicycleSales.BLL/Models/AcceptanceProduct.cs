namespace BicycleSales.BLL.Models;

public class AcceptanceProduct
{
    public int Id { get; set; }

    public int ProductCount { get; set; }
    public int? FactProductCount { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int AcceptanceId { get; set; }
    public Acceptance Acceptance { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is AcceptanceProduct acceptanceProduct &&
               Id == acceptanceProduct.Id &&
               ProductCount == acceptanceProduct.ProductCount &&
               FactProductCount == acceptanceProduct.FactProductCount &&
               ProductId == acceptanceProduct.ProductId &&
               Product.Equals(acceptanceProduct.Product) &&
               AcceptanceId == acceptanceProduct.AcceptanceId &&
               Acceptance.Equals(acceptanceProduct.Acceptance);
    }
}