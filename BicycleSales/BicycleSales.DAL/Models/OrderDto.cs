using BicycleSales.DAL.Constant;

namespace BicycleSales.DAL.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCompilation { get; set; }
        public DateTime DateOfCompletion { get; set; }
        public UserDto User { get; set; }
        public ShopDto Shop { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.OrderCreated;
    }

    public class OrderProductDto
    {
        public int ProductCount { get; set; }
        public int ReadyProductCount { get; set; }
        public OrderDto Order { get; set; }
        public ProductDto Product { get; set; }
    }
}
