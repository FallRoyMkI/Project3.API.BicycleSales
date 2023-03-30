
namespace BicycleSales.API.Models.OrderProduct.Request
{
    public class OrderProductUpdateRequest
    {
        public int ReadyProductCount { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
