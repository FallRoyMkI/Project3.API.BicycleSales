using BicycleSales.API.Models.Order.Response;
using BicycleSales.API.Models.Product.Response;

namespace BicycleSales.API.Models.OrderProduct.Response
{
    public class OrderProductResponse
    {
        public int ProductCount { get; set; }
        public int ReadyProductCount { get; set; }
        public OrderAddRequest Order { get; set; }
        public ProductAddRequest Product { get; set; }
    }
}
