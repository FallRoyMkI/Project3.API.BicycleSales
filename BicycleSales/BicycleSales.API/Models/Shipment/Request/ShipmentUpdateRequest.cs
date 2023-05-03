
namespace BicycleSales.API.Models.Shipment.Request
{
    public class ShipmentUpdateRequest
    {
        public int Id { get; set; }
        public DateTime FactTime { get; set; }
        public int SignedById { get; set; }
    }
}
