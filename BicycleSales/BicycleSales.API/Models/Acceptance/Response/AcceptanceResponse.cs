using BicycleSales.API.Models.Shop.Response;
using BicycleSales.API.Models.User.Response;

namespace BicycleSales.API.Models.Acceptance.Response
{
    public class AcceptanceAddRequest
    {
        public int Id { get; set; }
        public DateTime PlanedTime { get; set; }
        public DateTime FactTime { get; set; }
        public UserAddRequest FormedBy { get; set; }
        public UserAddRequest SignedBy { get; set; }
        public ShopAddRequest Shop { get; set; }
    }
}
