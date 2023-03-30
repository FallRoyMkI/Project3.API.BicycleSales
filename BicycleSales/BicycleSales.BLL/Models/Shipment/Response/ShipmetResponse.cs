using BicycleSales.BLL.Models.Shop.Response;
using BicycleSales.BLL.Models.User.Response;

namespace BicycleSales.BLL.Models.Shipment.Response
{
    public class ShipmetResponse
    {
        public int Id { get; set; }
        public DateTime PlanedTime { get; set; }
        public DateTime FactTime { get; set; }
        public UserResponse FormedBy { get; set; }
        public UserResponse SignedBy { get; set; }
        public ShopResponse Shop { get; set; }
    }
}
