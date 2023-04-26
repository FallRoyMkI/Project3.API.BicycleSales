using BicycleSales.Constants;

namespace BicycleSales.BLL.Models;

public class ShipmentAcceptance
{
    public int Id { get; set; }

    public ShipmentAcceptanceStatus Status { get; set; } = ShipmentAcceptanceStatus.ShipmentCreated;

    public int ShipmentId { get; set; }
    public Shipment Shipment { get; set; }

    public int AcceptanceId { get; set; }
    public Acceptance Acceptance { get; set; }

    public int FactoryId { get; set; }
    public Factory Factory { get; set; }


    public override bool Equals(object? obj)
    {
        return obj is ShipmentAcceptance shipmentAcceptance &&
               Id == shipmentAcceptance.Id &&
               Status == shipmentAcceptance.Status &&
               ShipmentId == shipmentAcceptance.ShipmentId &&
               Shipment.Equals(shipmentAcceptance.Shipment) &&
               AcceptanceId == shipmentAcceptance.AcceptanceId &&
               Acceptance.Equals(shipmentAcceptance.Acceptance) &&
               FactoryId == shipmentAcceptance.FactoryId &&
               Factory.Equals(shipmentAcceptance.Factory);
    }
}