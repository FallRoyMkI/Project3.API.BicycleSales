namespace BicycleSales.BLL.Models;

public class Acceptance
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
        return obj is Acceptance acceptance &&
               Id == acceptance.Id &&
               PlanedTime == acceptance.PlanedTime &&
               FactTime == acceptance.FactTime &&
               FormedById == acceptance.FormedById &&
               FormedBy.Equals(acceptance.FormedBy) &&
               SignedById == acceptance.SignedById &&
               SignedBy.Equals(acceptance.SignedBy) &&
               ShopId == acceptance.ShopId &&
               Shop.Equals(acceptance.Shop);
    }
}