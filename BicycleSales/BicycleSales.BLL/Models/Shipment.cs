namespace BicycleSales.BLL.Models;

public class Shipment
{
    public int Id { get; set; }

    public DateTime PlanedTime { get; set; }
    public DateTime? FactTime { get; set; }

    public int FormedById { get; set; }
    public User FormedBy { get; set; }

    public int? SignedById { get; set; }
    public User? SignedBy { get; set; }

    public int ShopId { get; set; }
    public Shop Shop { get; set; }
    
    public override bool Equals(object? obj)
    {
        return obj is Shipment shipment &&
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