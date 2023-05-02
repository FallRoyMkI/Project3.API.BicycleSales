using BicycleSales.API.Models.Order.Response;
using BicycleSales.API.Models.Product.Response;

namespace BicycleSales.API.Models.OrderProduct.Response
{
    public class OrderProductResponse
    {
        public int Id { get; set; }
        public int ProductCount { get; set; }
        public int? ReadyProductCount { get; set; }
        public ProductResponse Product { get; set; }
    }
}