using BicycleSales.API.Models.Product.Response;
using BicycleSales.API.Models.Shop.Response;

namespace BicycleSales.API.Models.ShopProduct.Response
{
    public class ShopProduct
    {
        public int ProductCount { get; set; }
        public ShopAddRequest ShopId { get; set; }
        public ProductAddRequest Product { get; set; }
    }
}
