using BicycleSales.API.Models.Acceptance.Response;
using BicycleSales.API.Models.Product.Response;

namespace BicycleSales.API.Models.AcceptanceProduct.Response;

public class AcceptanceProductResponse
{
    public int Id { get; set; }
    public ProductResponse Product { get; set; }
    public int ProductCount { get; set; }
    public int? FactProductCount { get; set; }
}