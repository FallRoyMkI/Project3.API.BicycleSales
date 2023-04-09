using BicycleSales.API.Models.Shop.Response;
using BicycleSales.API.Models.User.Response;
using BicycleSales.API.Models.OrderStatus.Response;
using BicycleSales.API.Models.Shop.Request;
using BicycleSales.API.Models.User.Request;

namespace BicycleSales.API.Models.Order.Response
{
    public class OrderAddRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCompilation { get; set; }
        public DateTime DateOfCompletion { get; set; }
        public UserAddRequest User { get; set; }
        public ShopAddRequest Shop { get; set; }
        public OrderSatusAddRequest OrderStatus { get; set; }
    }
}
