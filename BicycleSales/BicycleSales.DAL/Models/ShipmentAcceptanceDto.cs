
namespace BicycleSales.DAL.Models
{
    public class ShipmentAcceptanceDto
    {
        public ShipmetDto Shipment { get; set; }
        public AcceptanceDto Acceptance { get; set; }
        public StatusDto Status { get; set; }
        public FactoryDto Factory { get; set; }
    }
}
