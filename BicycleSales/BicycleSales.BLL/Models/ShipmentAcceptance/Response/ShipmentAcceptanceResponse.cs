using BicycleSales.BLL.Models.Acceptance.Response;
using BicycleSales.BLL.Models.Factory.Response;
using BicycleSales.BLL.Models.Shipment.Response;
using BicycleSales.BLL.Models.Status.Response;

namespace BicycleSales.BLL.Models.ShipmentAcceptance.Response
{
    public class ShipmentAcceptanceResponse
    {
        public ShipmetResponse Shipment { get; set; }
        public AcceptanceResponse Acceptance { get; set; }
        public StatusResponse Status { get; set; }
        public FactoryResponse Factory { get; set; }
    }
}
