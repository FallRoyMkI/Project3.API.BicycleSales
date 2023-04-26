using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BicycleSales.Constants;

namespace BicycleSales.DAL.Models;

public class ShipmentAcceptanceDto
{
    [Key]
    public int Id { get; set; }
    public ShipmentAcceptanceStatus Status { get; set; } = ShipmentAcceptanceStatus.ShipmentCreated;

    public int ShipmentId { get; set; }
    [ForeignKey(nameof(ShipmentId))]
    public ShipmentDto Shipment { get; set; }

    public int AcceptanceId { get; set; }
    [ForeignKey(nameof(AcceptanceId))]
    public AcceptanceDto Acceptance { get; set; }


    public int FactoryId { get; set; }
    [ForeignKey(nameof(FactoryId))]
    public FactoryDto Factory { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is ShipmentAcceptanceDto shipmentAcceptance &&
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