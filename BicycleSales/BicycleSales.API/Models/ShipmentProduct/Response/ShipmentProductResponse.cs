using BicycleSales.API.Models.Product.Response;
using BicycleSales.API.Models.Shipment.Response;

namespace BicycleSales.API.Models.ShipmentProduct.Response
{
    public class ShipmentProductResponse
    {
        public int Id { get; set; }
        public int ProductCount { get; set; }
        public int FactProductCount { get; set; }
        public ProductResponse Product { get; set; }
        public ShipmentResponse Shipment { get; set; }
    }
}
