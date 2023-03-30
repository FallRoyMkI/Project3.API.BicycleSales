
namespace BicycleSales.API.Models.ShipmentAcceptance.Request
{
    public class ShipmentAcceptanceAddRequest
    {
        public int ShipmentId { get; set; }
        public int AcceptanceId { get; set; }
        public int FactoryId { get; set; }
    }
}
