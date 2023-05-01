using BicycleSales.API.Models.Product.Response;
using BicycleSales.API.Models.Shop.Request;
using BicycleSales.API.Models.Shop.Response;

namespace BicycleSales.API.Models.ShopProduct.Response
{
    public class ShopProductResponse
    {
        public int ProductCount { get; set; }
        public ProductResponse Product { get; set; }
    }
}
