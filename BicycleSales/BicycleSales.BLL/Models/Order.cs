using BicycleSales.Constants;
namespace BicycleSales.BLL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCompilation { get; set; }
        public DateTime DateOfCompletion { get; set; }
        public User User { get; set; }
        public Shop Shop { get; set; }
        public OrderStatus Status { get; set; }
    }

    public class OrderProduct
    {
        public int ProductCount { get; set; }
        public int ReadyProductCount { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
