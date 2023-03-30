using BicycleSales.BLL.Models.Product.Response;
using BicycleSales.BLL.Models.Shipment.Response;

namespace BicycleSales.BLL.Models.ShipmentProduct.Response
{
    public class ShipmentProductResponse
    {
        public int Id { get; set; }
        public int ProductCount { get; set; }
        public int FactProductCount { get; set; }
        public ProductResponse Product { get; set; }
        public ShipmetResponse Shipment { get; set; }
    }
}
