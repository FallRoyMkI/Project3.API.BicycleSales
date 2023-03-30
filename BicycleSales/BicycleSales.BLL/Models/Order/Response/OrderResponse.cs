using BicycleSales.BLL.Models.OrderStatus.Response;
using BicycleSales.BLL.Models.Shop.Response;
using BicycleSales.BLL.Models.User.Response;

namespace BicycleSales.BLL.Models.Order.Response
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCompilation { get; set; }
        public DateTime DateOfCompletion { get; set; }
        public UserResponse User { get; set; }
        public ShopResponse Shop { get; set; }
        public OrderSatusResponse OrderStatus { get; set; }
    }
}
