
namespace BicycleSales.API.Models.Order.Request
{
    public class OrderAddRequest
    {
        public string Name { get; set; }
        public DateTime DateOfCompilation { get; set; }
        public int UserId { get; set; }
        public int ShopId { get; set; }
    }
}
