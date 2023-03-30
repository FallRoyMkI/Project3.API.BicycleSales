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
        public OrderSatus OrderStatus { get; set; }
    }
}
