using BicycleSales.API.Models.Acceptance.Response;
using BicycleSales.API.Models.Factory.Response;
using BicycleSales.API.Models.Shipment.Response;
using BicycleSales.API.Constant;

namespace BicycleSales.API.Models.ShipmentAcceptance.Response
{
    public class ShipmentAcceptanceResponse
    {
        public ShipmentResponse Shipment { get; set; }
        public AcceptanceResponse Acceptance { get; set; }
        public ShipmentAcceptanceStatus Status { get; set; }
        public FactoryResponse Factory { get; set; }
    }
}
