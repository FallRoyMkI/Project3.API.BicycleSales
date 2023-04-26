using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BicycleSales.DAL.Models;

public class ShipmentDto
{
    [Key]
    public int Id { get; set; }

    public DateTime PlanedTime { get; set; }
    public DateTime FactTime { get; set; }

    public int FormedById { get; set; }
    [ForeignKey(nameof(FormedById))]
    public UserDto FormedBy { get; set; }

    public int SignedById { get; set; }
    [ForeignKey(nameof(SignedById))]
    public UserDto SignedBy { get; set; }

    public int ShopId { get; set; }
    [ForeignKey(nameof(ShopId))]
    public ShopDto Shop { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is ShipmentDto shipment &&
               Id == shipment.Id &&
               PlanedTime == shipment.PlanedTime &&
               FactTime == shipment.FactTime &&
               FormedById == shipment.FormedById &&
               FormedBy.Equals(shipment.FormedBy) &&
               SignedById == shipment.SignedById &&
               SignedBy.Equals(shipment.SignedBy) &&
               ShopId == shipment.ShopId &&
               Shop.Equals(shipment.Shop);
    }
}