
namespace BicycleSales.BLL.Models
{
    public class ShipmentAcceptance
    {
        public Shipmet Shipment { get; set; }
        public Acceptance Acceptance { get; set; }
        public Status Status { get; set; }
        public Factory Factory { get; set; }
    }
}
