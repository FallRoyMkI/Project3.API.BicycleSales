using BicycleSales.API.Models.Product.Response;

namespace BicycleSales.API.Models.ShipmentProduct.Response;

public class ShipmentProductLowInfoResponse
{
    public int Id { get; set; }
    public int ProductCount { get; set; }
    public int? FactProductCount { get; set; }
    public ProductResponse Product { get; set; }
}