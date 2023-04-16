using BicycleSales.Constants;

namespace BicycleSales.BLL.Models
{
    public class ShipmentAcceptance
    {
        public Shipment Shipment { get; set; }
        public Acceptance Acceptance { get; set; }
        public ShipmentAcceptanceStatus Status { get; set; } = ShipmentAcceptanceStatus.ShipmentCreated;
        public Factory Factory { get; set; }
    }

    public class Factory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
