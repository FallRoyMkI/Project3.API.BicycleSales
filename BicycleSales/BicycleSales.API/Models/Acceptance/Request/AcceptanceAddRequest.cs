namespace BicycleSales.API.Models.Acceptance.Request;

public class AcceptanceAddRequest
{
    public DateTime PlanedTime { get; set; }
    public int ShopId { get; set; }
    public int FormedById { get; set; }
}