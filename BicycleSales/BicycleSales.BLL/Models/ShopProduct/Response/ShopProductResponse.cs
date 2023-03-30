using BicycleSales.BLL.Models.Product.Response;
using BicycleSales.BLL.Models.Shop.Response;

namespace BicycleSales.BLL.Models.ShopProduct.Response
{
    public class ShopProductResponse
    {
        public int ProductCount { get; set; }
        public ShopResponse ShopId { get; set; }
        public ProductResponse Product { get; set; }
    }
}
