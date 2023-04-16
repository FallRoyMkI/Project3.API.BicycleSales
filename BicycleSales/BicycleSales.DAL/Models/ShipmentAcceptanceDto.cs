using BicycleSales.Constants;

namespace BicycleSales.DAL.Models
{
    public class ShipmentAcceptanceDto
    {
        public ShipmentDto Shipment { get; set; }
        public AcceptanceDto Acceptance { get; set; }
        public ShipmentAcceptanceStatus Status { get; set; } = ShipmentAcceptanceStatus.ShipmentCreated;
        public FactoryDto Factory { get; set; }
    }

    public class FactoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
