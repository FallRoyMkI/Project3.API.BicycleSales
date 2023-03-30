
namespace BicycleSales.API.Models.ShopProduct.Request
{
    public class ShopProductUpdateRequest
    {
        public int ProductCount { get; set; }
        public int ShopId { get; set; }
        public int ProductId { get; set; }
    }
}
