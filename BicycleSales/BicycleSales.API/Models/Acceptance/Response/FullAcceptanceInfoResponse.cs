using BicycleSales.API.Models.AcceptanceProduct.Response;
using BicycleSales.API.Models.Shop.Response;
using BicycleSales.API.Models.User.Response;

namespace BicycleSales.API.Models.Acceptance.Response;

public class FullAcceptanceInfoResponse
{
    public int Id { get; set; }
    public DateTime PlanedTime { get; set; }
    public DateTime? FactTime { get; set; }
    public UserResponse FormedBy { get; set; }
    public UserResponse SignedBy { get; set; }
    public ShopResponse Shop { get; set; }

    public List<AcceptanceProductLowInfoResponse> Products { get; set; }
}