using BicycleSales.BLL.Models.Order.Response;
using BicycleSales.BLL.Models.Product.Response;

namespace BicycleSales.BLL.Models.OrderProduct.Response
{
    public class OrderProductResponsecs
    {
        public int ProductCount { get; set; }
        public int ReadyProductCount { get; set; }
        public OrderResponse Order { get; set;}
        public ProductResponse Product { get; set; }
    }
}
