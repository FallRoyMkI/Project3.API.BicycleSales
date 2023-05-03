
namespace BicycleSales.API.Models.Shipment.Request
{
    public class ShipmentAddRequest
    {
        public DateTime PlanedTime { get; set; }
        public int FormedById { get; set; }
        public int ShopId { get; set; }
    }
}
