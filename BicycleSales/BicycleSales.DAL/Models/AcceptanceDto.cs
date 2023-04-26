using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BicycleSales.DAL.Models;

public class AcceptanceDto
{
    [Key]
    public int Id { get; set; }

    public DateTime PlanedTime { get; set; }
    public DateTime? FactTime { get; set; }

    public int FormedById { get; set; }
    [ForeignKey(nameof(FormedById))]
    public UserDto FormedBy { get; set; }

    public int? SignedById { get; set; }
    [ForeignKey(nameof(SignedById))]
    public UserDto? SignedBy { get; set; }

    public int ShopId { get; set; }
    [ForeignKey(nameof(ShopId))]
    public ShopDto Shop { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is AcceptanceDto acceptance &&
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