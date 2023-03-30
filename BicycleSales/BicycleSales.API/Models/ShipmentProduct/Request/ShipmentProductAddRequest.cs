
namespace BicycleSales.API.Models.ShipmentProduct.Request
{
    public class ShipmentProductAddRequest
    {
        public int ProductCount { get; set; }
        public int ProductId { get; set; }
        public int ShipmentId { get; set; }
    }
}
