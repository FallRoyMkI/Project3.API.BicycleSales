
namespace BicycleSales.API.Models.OrderProduct.Request
{
    public class OrderProductAddRequest
    {
        public int ProductCount { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
