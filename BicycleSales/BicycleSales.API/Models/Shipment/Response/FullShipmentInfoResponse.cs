using BicycleSales.API.Models.AcceptanceProduct.Response;
using BicycleSales.API.Models.ShipmentProduct.Response;
using BicycleSales.API.Models.Shop.Response;
using BicycleSales.API.Models.User.Response;

namespace BicycleSales.API.Models.Shipment.Response;

public class FullShipmentInfoResponse
{
    public int Id { get; set; }
    public DateTime PlanedTime { get; set; }
    public DateTime? FactTime { get; set; }
    public UserResponse FormedBy { get; set; }
    public UserResponse SignedBy { get; set; }
    public ShopResponse Shop { get; set; }

    public List<ShipmentProductLowInfoResponse> Products { get; set; }
}