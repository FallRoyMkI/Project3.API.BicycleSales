using BicycleSales.API.Models.Acceptance.Response;
using BicycleSales.API.Models.Factory.Response;
using BicycleSales.API.Models.Shipment.Response;
using BicycleSales.API.Models.Status.Response;

namespace BicycleSales.API.Models.ShipmentAcceptance.Response
{
    public class ShipmentAcceptance
    {
        public ShipmetAddRequest Shipment { get; set; }
        public AcceptanceAddRequest Acceptance { get; set; }
        public StatusAddRequest Status { get; set; }
        public FactoryAddRequest Factory { get; set; }
    }
}
