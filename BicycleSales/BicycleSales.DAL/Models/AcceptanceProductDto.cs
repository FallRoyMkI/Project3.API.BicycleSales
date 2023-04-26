using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BicycleSales.DAL.Models;

public class AcceptanceProductDto
{
    [Key]
    public int Id { get; set; }

    public int ProductCount { get; set; }
    public int? FactProductCount { get; set; }

    public int ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public ProductDto Product { get; set; }

    public int AcceptanceId { get; set; }
    [ForeignKey(nameof(AcceptanceId))]
    public AcceptanceDto Acceptance { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is AcceptanceProductDto acceptanceProduct &&
               Id == acceptanceProduct.Id &&
               ProductCount == acceptanceProduct.ProductCount &&
               FactProductCount == acceptanceProduct.FactProductCount &&
               ProductId == acceptanceProduct.ProductId &&
               Product.Equals(acceptanceProduct.Product) &&
               AcceptanceId == acceptanceProduct.AcceptanceId &&
               Acceptance.Equals(acceptanceProduct.Acceptance);
    }
}