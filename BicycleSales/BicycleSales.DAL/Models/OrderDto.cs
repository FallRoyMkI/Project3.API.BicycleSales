namespace BicycleSales.BLL.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCompilation { get; set; }
        public DateTime DateOfCompletion { get; set; }
        public UserDto User { get; set; }
        public ShopDto Shop { get; set; }
        public OrderSatusDto OrderStatus { get; set; }
    }
}
