
namespace BicycleSales.API.Models.ShipmentAcceptance.Request
{
    public class ShipmentAcceptanceUpdateRequest
    {
        public int ShipmentId { get; set; }
        public int AcceptanceId { get; set; }
        public int FactoryId { get; set; }
        public int StatusId { get; set; }
    }
}
